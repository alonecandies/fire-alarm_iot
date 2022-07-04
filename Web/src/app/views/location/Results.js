import React from 'react'
import clsx from 'clsx'
import PerfectScrollbar from 'react-perfect-scrollbar'
import {
	Box,
	Card,
	makeStyles,
	Table,
	TableBody,
	TableCell,
	TableHead,
	TableRow,
	Tooltip,
} from '@material-ui/core'
import EditIcon from '@material-ui/icons/Edit'
import LoadingComponent from 'src/app/components/Loading'
import { ACTION_TABLE } from 'src/app/constant/config'
import moment from 'moment/moment'
import CustomErrorMessage from '../../components/CustomErrorMsg'

const Row = ({ data, onEditLocation, createRef }) => {
	const classes = useStyles()
	const row = data
	const createLocationTour = () => {
		if (!createRef) return
		createRef({
			parent_id: row.id,
			type: row.type,
		})
	}

	return (
		data && (
			<React.Fragment>
				{/*-------------Main row ----------*/}
				<TableRow>
					<TableCell align='left' component='th' scope='row'>
						{row.index + 1}
					</TableCell>
					<TableCell align='left'>{row.location_name}</TableCell>
					<TableCell align='left'>
						{moment(row.updated_at).format('LLLL')}
					</TableCell>

					<TableCell>
						<div className={classes.groupAction}>
							{/*<div*/}
							{/*	className='action'*/}
							{/*	onClick={() =>*/}
							{/*		onEditLocation(ACTION_TABLE.DETAIL, row)*/}
							{/*	}>*/}
							{/*	<Tooltip title='Chi tiết'>*/}
							{/*		<Eye />*/}
							{/*	</Tooltip>*/}
							{/*</div>*/}
							<div
								className='action'
								onClick={() =>
									onEditLocation(ACTION_TABLE.EDIT, row)
								}>
								<Tooltip title='Sửa'>
									<EditIcon />
								</Tooltip>
							</div>
							{/*<div*/}
							{/*	className='action'*/}
							{/*	onClick={() => onDeleteLocation(row)}>*/}
							{/*	<Tooltip title='Xóa'>*/}
							{/*		<DeleteIcon />*/}
							{/*	</Tooltip>*/}
							{/*</div>*/}
						</div>
					</TableCell>
				</TableRow>
			</React.Fragment>
		)
	)
}

const Results = ({
	className,
	locationData,
	isLoading,
	getListLocationRef,
	actionDetailsLocationRef,
	totalLocation,
	err,
	actionDeleteLocationRef,
	checkPermissionEdit,
	createRef,
	...rest
}) => {
	const classes = useStyles()
	const onEditLocation = (type, station) => {
		if (!actionDetailsLocationRef) return
		const sendData = { type: ACTION_TABLE.EDIT, data: station }
		actionDetailsLocationRef(sendData)
	}
	const onDeleteLocation = station => {
		if (!actionDeleteLocationRef) return
		actionDeleteLocationRef(station)
	}

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
										<TableCell>Ngày tạo</TableCell>
										<TableCell>Thao tác</TableCell>
									</TableRow>
								</TableHead>
								<TableBody>
									{locationData?.map((row, index) => (
										<Row
											data={{ ...row, index: index }}
											key={index}
											onDeleteLocation={onDeleteLocation}
											onEditLocation={onEditLocation}
											createRef={createRef}
										/>
									))}
								</TableBody>
							</Table>
						</Box>
					</PerfectScrollbar>
				</div>
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
