import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import Proptypes from 'prop-types'
import {
	AppBar,
	Box,
	Card,
	CardContent,
	Container,
	Dialog,
	Grid,
	makeStyles,
	Slide,
	Table,
	TableBody,
	TableCell,
	TableHead,
	TableRow,
} from '@material-ui/core'
import { green } from '@material-ui/core/colors'
import { DEVICE_STATUS, STATUS_API } from 'src/app/constant/config'
import ToolbarEdit from './Toolbar'
import {
	getDataDevice,
	getDetailDevice,
	getPhoneByDevice,
} from '../../../../features/deviceSlice'
import LoadingComponent from '../../../components/Loading'
import {
	Android,
	EventAvailable,
	LocationOn,
	NotificationsActive,
	Opacity,
	Vibration,
	WbIncandescent,
} from '@material-ui/icons'
import Typography from '@material-ui/core/Typography'
import moment from 'moment/moment'
import ChartTable from './ChartTable'

const Transition = React.forwardRef(function Transition(props, ref) {
	return <Slide direction='up' ref={ref} {...props} />
})

const InformationRow = ({ icon, title, value }) => {
	const classes = useStyles()
	return (
		<Grid container className={classes.rowInformation}>
			<Grid className={classes.rowInforName}>
				<Grid>{icon}</Grid>
				<Grid>{`\u00A0 ${title}`}</Grid>
			</Grid>
			<Grid>
				<Typography variant={'caption'}>{value}</Typography>
			</Grid>
		</Grid>
	)
}
InformationRow.propTypes = {
	icon: Proptypes.element,
	title: Proptypes.string.isRequired,
	value: Proptypes.string.isRequired,
}
function DetailsDevice({ open, sendData, closeRef }) {
	const classes = useStyles()
	const dispatch = useDispatch()
	const handleClose = () => {
		if (!closeRef) return
		closeRef()
	}
	const Device = sendData.data
	const detailDevice = useSelector(state => state.deviceSlice.detailDevice)
	const statusGetDetail = useSelector(
		state => state.deviceSlice.statusGetDetail
	)
	const statusGetData = useSelector(state => state.deviceSlice.statusGetData)
	const listData = useSelector(state => state.deviceSlice.listData)
	const listDataContact = useSelector(
		state => state.deviceSlice.listDataContact
	)
	useEffect(() => {
		dispatch(getDetailDevice(Device))
	}, [dispatch])
	useEffect(() => {
		dispatch(getDataDevice(Device))
	}, [dispatch])
	useEffect(() => {
		dispatch(getPhoneByDevice(Device))
	}, [dispatch])
	return (
		<div>
			<Dialog
				fullScreen
				open={open}
				onClose={() => handleClose()}
				TransitionComponent={Transition}>
				<AppBar className={classes.appBar}>
					<ToolbarEdit
						closeToolbarRef={handleClose}
						type={sendData.type}
					/>
				</AppBar>
				{statusGetDetail === STATUS_API.PENDING ? (
					<LoadingComponent />
				) : (
					detailDevice && (
						<Container maxWidth='lg'>
							<Grid container spacing={6}>
								{/*=============================column information=========================*/}
								<Grid
									item
									lg={4}
									md={5}
									xs={12}
									style={{
										paddingTop: '50px',
									}}>
									<Card className={classes.shadowBox}>
										<CardContent>
											<Box
												className={
													classes.headerDivider
												}>
												<Typography variant={'h6'}>
													Thông tin chung
												</Typography>
											</Box>
											<InformationRow
												icon={<Android />}
												title={'Tên thiết bị'}
												value={detailDevice.name}
											/>
											<InformationRow
												icon={<LocationOn />}
												title={'Vị trí lắp đặt'}
												value={
													detailDevice.station_name
												}
											/>
											<InformationRow
												icon={<WbIncandescent />}
												title={'Nhiệt độ báo động'}
												value={
													<>
														{
															detailDevice.max_temperature
														}
														&#8451;
													</>
												}
											/>
											<InformationRow
												icon={<EventAvailable />}
												title={'Ngày lắp đặt'}
												value={moment(
													detailDevice.created_at
												).format('LLLL')}
											/>
											{/*====================Thông tin chung ==================================*/}
											<Box
												className={
													classes.headerDivider
												}>
												<Typography variant={'h6'}>
													Trạng thái
												</Typography>
											</Box>
											<InformationRow
												icon={<Vibration />}
												title={'Tình Trạng'}
												value={
													detailDevice.is_off
														? DEVICE_STATUS.OFF
														: DEVICE_STATUS.ACTIVE
												}
											/>
											<InformationRow
												icon={<NotificationsActive />}
												title={'Trạng thái Chuông'}
												value={
													detailDevice.is_alert
														? DEVICE_STATUS.ACTIVE
														: DEVICE_STATUS.OFF
												}
											/>
											<InformationRow
												icon={<Opacity />}
												title={'Trạng thái Vòi phun'}
												value={
													detailDevice.is_sendWater
														? DEVICE_STATUS.ACTIVE
														: DEVICE_STATUS.OFF
												}
											/>
											{/*====================Thông tin BGT ==================================*/}
										</CardContent>
									</Card>
									<br />
									<br />
									<Card className={classes.shadowBox}>
										<Box className={classes.headerDivider}>
											<Typography variant={'h6'}>
												Danh bạ liên lạc
											</Typography>
										</Box>
										<Table>
											<TableHead>
												<TableRow>
													<TableCell>STT</TableCell>
													<TableCell>
														Tên liên lạc
													</TableCell>
													<TableCell>
														Số điện thoại
													</TableCell>
												</TableRow>
											</TableHead>
											<TableBody>
												{listDataContact &&
													listDataContact.map(
														(item, index) => {
															return (
																<TableRow
																	key={index}>
																	<TableCell>
																		{index +
																			1}
																	</TableCell>
																	<TableCell>
																		{
																			item.whole_name
																		}
																	</TableCell>
																	<TableCell>
																		{
																			item.phone_value
																		}
																	</TableCell>
																</TableRow>
															)
														}
													)}
											</TableBody>
										</Table>
									</Card>
								</Grid>
								{/*=============================column chart=========================*/}
								<Grid
									item
									lg={8}
									md={7}
									xs={12}
									style={{
										paddingTop: '50px',
									}}>
									{statusGetData === STATUS_API.PENDING ? (
										<LoadingComponent />
									) : (
										listData && (
											<Card className={classes.shadowBox}>
												<CardContent>
													<Grid container spacing={3}>
														<ChartTable
															data={listData}
														/>
													</Grid>
												</CardContent>
											</Card>
										)
									)}
								</Grid>
							</Grid>
						</Container>
					)
				)}
				{/*{isChangeUpdateDevice && isSubmited ? (*/}
				{/*	<ToastMessage*/}
				{/*		callBack={() => dispatch(resetChangeUpdateDevice())}*/}
				{/*		message={*/}
				{/*			isChangeUpdateDevice == STATUS_API.SUCCESS*/}
				{/*				? MESSAGE.UPDATE_CATEGORY_SUCCESS*/}
				{/*				: MESSAGE.UPDATE_CATEGORY_FAIL*/}
				{/*		}*/}
				{/*		type={*/}
				{/*			isChangeUpdateDevice == STATUS_API.SUCCESS*/}
				{/*				? messageToastType_const.success*/}
				{/*				: messageToastType_const.error*/}
				{/*		}*/}
				{/*	/>*/}
				{/*) : (*/}
				{/*	''*/}
				{/*)}*/}
				{/*{isChangeCreateDevice && isSubmited ? (*/}
				{/*	<ToastMessage*/}
				{/*		callBack={() => dispatch(resetChangeUpdateDevice())}*/}
				{/*		message={*/}
				{/*			isChangeCreateDevice === STATUS_API.SUCCESS*/}
				{/*				? MESSAGE.CREATE_CATEGORY_SUCCESS*/}
				{/*				: MESSAGE.CREATE_CATEGORY_FAIL*/}
				{/*		}*/}
				{/*		type={*/}
				{/*			isChangeCreateDevice === STATUS_API.SUCCESS*/}
				{/*				? messageToastType_const.success*/}
				{/*				: messageToastType_const.error*/}
				{/*		}*/}
				{/*	/>*/}
				{/*) : (*/}
				{/*	''*/}
				{/*)}*/}
			</Dialog>
		</div>
	)
}

const useStyles = makeStyles(theme => ({
	appBar: {
		position: 'relative',
	},
	shadowBox: {
		boxShadow: '0 2px 5px rgba(0,0,0,.18)',
	},
	title: {
		marginLeft: theme.spacing(2),
		flex: 1,
	},
	root: {
		minHeight: '100%',
		paddingBottom: theme.spacing(3),
		paddingTop: theme.spacing(3),
	},
	groupButtonSubmit: {
		display: 'flex',
		justifyContent: 'space-between',
		alignItems: 'center',
		marginTop: '15px',

		'& .left-button': {
			display: 'flex',
		},
	},
	formControl: {
		margin: theme.spacing(1),
		minWidth: 200,
	},
	avatar: {
		height: 100,
		width: 100,
	},
	importButton: {
		marginRight: theme.spacing(1),
	},
	wrapper: {
		position: 'relative',
	},
	buttonProgress: {
		color: green[500],
		position: 'absolute',
		top: '50%',
		left: '50%',
		marginTop: -12,
		marginLeft: -12,
	},
	disableForm: {
		pointerEvents: 'none',
	},
	colorWhite: {
		color: '#fff',
	},
	rowInformation: {
		display: 'flex',
		justifyContent: 'space-between',
		marginBottom: '15px',
	},
	rowInforName: {
		display: 'flex',
	},
	headerDivider: {
		backgroundColor: '#e8e7e7',
		padding: theme.spacing(1),
		marginBottom: '15px',
	},
}))

export default DetailsDevice
