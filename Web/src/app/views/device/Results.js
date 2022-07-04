import React, { useEffect } from 'react'
import clsx from 'clsx'
import PerfectScrollbar from 'react-perfect-scrollbar'
import {
	Box,
	Button,
	Card,
	Chip,
	makeStyles,
	Table,
	TableBody,
	TableCell,
	TableHead,
	TableRow,
	Tooltip,
} from '@material-ui/core'
import DeleteIcon from '@material-ui/icons/Delete'
import EditIcon from '@material-ui/icons/Edit'
import LoadingComponent from 'src/app/components/Loading'
import {
	ACTION_TABLE,
	DEVICE_STATUS,
	messageToastType_const,
	STATUS_API,
} from 'src/app/constant/config'
import {
	InvertColors,
	InvertColorsOff,
	NotificationsActiveRounded,
	NotificationsOff,
} from '@material-ui/icons'
import CustomErrorMessage from '../../components/CustomErrorMsg'
import { Eye } from 'react-feather'
import NullData from '../../components/NullData'
import DialogConfirm from '../../components/DialogConfirm'
import { useDispatch, useSelector } from 'react-redux'
import { editDevice } from '../../../features/deviceSlice'
import { showDialogConfirm, showToast } from '../../../features/uiSlice'
import ToastMessage from '../../components/ToastMessage'
import { clearMSg } from '../../../features/locationSlice'
import { MESSAGE } from '../../constant/message'

const Row = ({
	data,
	dispatch,
	onViewDevice,
	onEditDevice,
	onDeleteDevice,
	onEditAlertAndWater,
}) => {
	const classes = useStyles()
	const row = data
	const [isShowChangeAlert, setIsShowChangeAlert] = React.useState(false)
	const [isShowChangeWater, setIsShowChangeWater] = React.useState(false)
	const handleEditAlert = () => {
		setIsShowChangeAlert(true)
		dispatch(showDialogConfirm())
	}
	const handleEditWater = () => {
		dispatch(showDialogConfirm())
		setIsShowChangeWater(true)
	}
	const changeAlertStatus = () => {
		let tmp = { ...row, is_alert: !row.is_alert }
		setIsShowChangeAlert(false)
		onEditAlertAndWater(tmp)
	}
	const changeWaterStatus = () => {
		let tmp = { ...row, is_sendWater: !row.is_sendWater }
		setIsShowChangeWater(false)
		onEditAlertAndWater(tmp)
	}
	return (
		data && (
			<React.Fragment>
				{/*-------------Main row ----------*/}
				<TableRow>
					<TableCell align='left' component='th' scope='row'>
						{row.index + 1}
					</TableCell>
					<TableCell align='left'>{row.name}</TableCell>
					<TableCell align='left'>{row.station_name}</TableCell>
					<TableCell align='left'>{row.max_temperature} &#8451;</TableCell>
					<TableCell align='center'>
						<Chip
							onClick={handleEditAlert}
							clickable
							variant={'outlined'}
							label={row.is_alert ? 'Đang reo' : 'Không hoạt động'}
							icon={
								row.is_alert ? (
									<NotificationsActiveRounded />
								) : (
									<NotificationsOff />
								)
							}
							color={row.is_alert ? 'secondary' : 'default'}
						/>
					</TableCell>
					<TableCell align='center'>
						<Chip
							onClick={handleEditWater}
							clickable
							variant={'outlined'}
							label={row.is_sendWater ? 'Đang phun' : 'Không hoạt động'}
							icon={row.is_sendWater ? <InvertColors /> : <InvertColorsOff />}
							color={row.is_sendWater ? 'primary' : 'default'}
						/>
					</TableCell>

					<TableCell>
						<div className={classes.groupAction}>
							<div
								className='action'
								onClick={() => onViewDevice(ACTION_TABLE.DETAIL, row)}>
								<Tooltip title='Chi tiết'>
									<Eye />
								</Tooltip>
							</div>
							<div
								className='action'
								onClick={() => onEditDevice(ACTION_TABLE.EDIT, row)}>
								<Tooltip title='Sửa'>
									<EditIcon />
								</Tooltip>
							</div>
						</div>
					</TableCell>
				</TableRow>
				{isShowChangeAlert && (
					<DialogConfirm
						title={'Thay đổi trạng thái chuông báo động'}
						callbackOk={changeAlertStatus}
						callbackCancel={() => setIsShowChangeAlert(false)}
					/>
				)}
				{isShowChangeWater && (
					<DialogConfirm
						title={'Thay đổi trạng thái máy phun nước'}
						callbackOk={changeWaterStatus}
						callbackCancel={() => setIsShowChangeWater(false)}
					/>
				)}
			</React.Fragment>
		)
	)
}

const Results = ({
	className,
	deviceData,
	isLoading,
	getListDeviceRef,
	actionDetailsDeviceRef,
	totalDevice,
	err,
	actionEditDevice,
	actionDeleteDeviceRef,
	checkPermissionEdit,
	createRef,
	...rest
}) => {
	const classes = useStyles()

	const dispatch = useDispatch()

	const [isSubmit, setSubmit] = React.useState(false)
	const onViewDevice = (type, data) => {
		if (!actionDetailsDeviceRef) return
		const sendData = { type: type, data: data }
		actionDetailsDeviceRef(sendData)
	}
	const onEditDevice = (type, device) => {
		if (!actionEditDevice) return
		const sendData = { type: ACTION_TABLE.EDIT, data: device }
		actionEditDevice(sendData)
	}
	const onDeleteDevice = device => {
		if (!actionDeleteDeviceRef) return
		actionDeleteDeviceRef(device)
	}
	const onEditAlertAndWater = device => {
		setSubmit(true)
		dispatch(editDevice(device))
	}

	const statusEdit = useSelector(state => state.deviceSlice.statusEdit)

	useEffect(() => {
		if (statusEdit === STATUS_API.SUCCESS || statusEdit === STATUS_API.ERROR) {
			dispatch(showToast())
		}
	}, [statusEdit])

	if (err) return <CustomErrorMessage content={err} />
	return (
		<Card className={clsx(classes.root, className)} {...rest}>
			{isLoading ? (
				<LoadingComponent />
			) : (
				<div>
					<PerfectScrollbar>
						<Box minWidth={1050}>
							<Table>
								<TableHead>
									<TableRow>
										<TableCell>STT</TableCell>
										<TableCell>Tên </TableCell>
										<TableCell>Địa điểm </TableCell>
										<TableCell>Nhiệt độ báo động</TableCell>
										{/*<TableCell>Trạng thái</TableCell>*/}
										{/*<TableCell>Ngày lắp đặt</TableCell>*/}
										<TableCell>Chuông báo động</TableCell>
										<TableCell>Máy phun nước</TableCell>
										<TableCell>Thao tác</TableCell>
									</TableRow>
								</TableHead>
								<TableBody>
									{deviceData && deviceData?.length === 0 && (
										<TableRow>
											<TableCell colSpan={7}>
												{' '}
												<NullData />
											</TableCell>
										</TableRow>
									)}
									{deviceData?.map((row, index) => (
										<Row
											dispatch={dispatch}
											data={{ ...row, index: index }}
											key={index}
											onEditAlertAndWater={onEditAlertAndWater}
											onViewDevice={onViewDevice}
											onDeleteDevice={onDeleteDevice}
											onEditDevice={onEditDevice}
											createRef={createRef}
										/>
									))}
								</TableBody>
							</Table>
						</Box>
					</PerfectScrollbar>
				</div>
			)}
			{isSubmit &&
				(statusEdit === STATUS_API.ERROR ||
					statusEdit === STATUS_API.SUCCESS) && (
					<ToastMessage
						callBack={() => dispatch(clearMSg())}
						message={
							statusEdit === STATUS_API.SUCCESS
								? MESSAGE.EDIT_STATUS_SUCCESS
								: MESSAGE.EDIT_STATUS_FAIL
						}
						type={
							statusEdit === STATUS_API.SUCCESS
								? messageToastType_const.success
								: messageToastType_const.error
						}
					/>
				)}
		</Card>
	)
}

const useStyles = makeStyles(theme => ({
	root: {
		position: 'relative',
	},
	avatar: {
		marginRight: theme.spacing(2),
	},
	groupAction: {
		display: 'flex',
		alignItems: 'center',
		'& .action': {
			cursor: 'pointer',
			padding: '0 5px',
			'&:hover': {
				color: '#3f51b5',
			},
		},
	},
	minWithColumn: {
		minWidth: '150px',
	},
	groupSearch: {
		display: 'flex',
		paddingTop: 15,
		alignItems: 'center',
		justifyContent: 'space-between',
	},
}))

export default Results
