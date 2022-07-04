import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import {
	AppBar,
	Box,
	Button,
	Card,
	CardContent,
	Container,
	Dialog,
	Divider,
	Grid,
	makeStyles,
	Slide,
	TextField,
} from '@material-ui/core'
import CircularProgress from '@material-ui/core/CircularProgress'
import { green } from '@material-ui/core/colors'
import {
	ACTION_TABLE,
	messageToastType_const,
	STATUS_API,
} from '../../../constant/config'
import * as Yup from 'yup'
import { Formik } from 'formik'
import ToolbarEdit from './Toolbar'
import { clearMsg } from '../../../../features/deviceSlice'
import { MESSAGE } from '../../../constant/message'
import ToastMessage from '../../../components/ToastMessage'
import { showToast } from '../../../../features/uiSlice'
import { Autocomplete } from '@material-ui/lab'
import { createDevice, editDevice } from '../../../../features/deviceSlice'

const Transition = React.forwardRef(function Transition(props, ref) {
	return <Slide direction='up' ref={ref} {...props} />
})
function FormEditDevice({
	open,
	sendData,
	closeRef,
	isLoadingLocation,
	locationData,
}) {
	const classes = useStyles()
	const dispatch = useDispatch()

	const handleClose = () => {
		if (!closeRef) return
		closeRef()
	}
	const statusCreate = useSelector(state => state.deviceSlice.statusCreate)
	const statusEdit = useSelector(state => state.deviceSlice.statusEdit)

	const [isSubmit, setIsSubmit] = React.useState(false)
	const handleSubmit = data => {
		setIsSubmit(true)
		console.log(data)
		if (sendData.type === ACTION_TABLE.CREATE) {
			dispatch(createDevice(data))
		} else dispatch(editDevice(data))
	}

	useEffect(() => {
		if (
			statusCreate !== STATUS_API.PENDING ||
			statusEdit !== STATUS_API.PENDING
		) {
			dispatch(showToast())
		}
	}, [statusEdit, statusCreate])
	console.log(sendData)
	const initValue =
		sendData.type === ACTION_TABLE.EDIT
			? sendData.data
			: {
					name: '',
					max_temperature: undefined,
					is_off: false,
					is_alert: false,
					is_sendWater: false,
					station_id: undefined,
					station_name: '',
			  }
	return (
		<>
			<Dialog
				fullWidth
				maxWidth={'md'}
				open={open}
				onClose={() => handleClose()}
				TransitionComponent={Transition}>
				<AppBar className={classes.appBar}>
					<ToolbarEdit closeToolbarRef={handleClose} type={sendData.type} />
				</AppBar>

				<Container maxWidth='lg'>
					<Grid container spacing={3}>
						<Grid
							item
							lg={12}
							md={12}
							xs={12}
							style={{
								paddingTop: '50px',
								paddingBottom: '50px',
							}}>
							<Card className={classes.shadowBox}>
								<CardContent>
									<Formik
										initialValues={{ ...initValue }}
										validationSchema={Yup.object().shape({
											name: Yup.string().required('Tên không được để trống'),
											max_temperature: Yup.number()
												.typeError('Nhiệt độ phải là dạng số')
												.required('Nhiệt độ không được để trống'),
											station_name: Yup.string()
												.typeError('Địa điểm không được để trống')
												.required('Địa điểm không được để trống'),
										})}
										onSubmit={handleSubmit}>
										{({
											errors,
											handleBlur,
											handleChange,
											handleSubmit,
											touched,
											values,
											setFieldValue,
										}) => (
											<form onSubmit={handleSubmit}>
												<Grid container spacing={5}>
													<Grid item md={12} xs={12}>
														<TextField
															error={Boolean(touched.name && errors.name)}
															fullWidth
															helperText={touched.name && errors.name}
															label='Tên Device'
															margin='normal'
															name='name'
															onBlur={handleBlur}
															onChange={handleChange}
															value={values.name}
															variant='outlined'
														/>
													</Grid>
													<Grid
														item
														md={6}
														xs={12}
														style={{
															display: 'flex',
															alignItems: 'center',
														}}>
														<TextField
															error={Boolean(
																touched.max_temperature &&
																	errors.max_temperature
															)}
															fullWidth
															helperText={
																touched.max_temperature &&
																errors.max_temperature
															}
															label='Nhiệt độ ngưỡng'
															margin='normal'
															name='max_temperature'
															onBlur={handleBlur}
															onChange={handleChange}
															value={values.max_temperature}
															variant='outlined'
														/>
													</Grid>

													<Grid
														item
														md={6}
														xs={12}
														style={{
															display: 'flex',
															alignItems: 'center',
														}}>
														<Autocomplete
															defaultValue={
																locationData.filter(
																	item => item.id === sendData.data.station_id
																)[0] || ''
															}
															getOptionLabel={option => option.location_name}
															onBlur={handleBlur}
															// onOpen={e => {
															// 	if (
															// 		sendData.type === ACTION_TABLE.EDIT &&
															// 		values.location_name
															// 	) {
															// 		console.log(' open listener')
															// 		setFieldValue(
															// 			'station_name',
															// 			sendData.data.station_name
															// 		)
															// 		return
															// 	}
															// 	handleBlur(e)
															// }}
															onChange={(event, newValue) => {
																console.log('change listener', newValue)
																handleChange(event)
																setFieldValue(
																	'station_name',
																	newValue?.location_name || ''
																)
																setFieldValue(
																	'station_id',
																	newValue?.id || undefined
																)
															}}
															loading={isLoadingLocation}
															options={locationData}
															style={{
																width: '100%',
															}}
															renderInput={params => (
																<TextField
																	error={Boolean(
																		touched.station_name && errors.station_name
																	)}
																	helperText={
																		touched.station_name && errors.station_name
																	}
																	name={'station_name'}
																	{...params}
																	label='Địa điểm'
																	variant='outlined'
																/>
															)}
														/>
													</Grid>
												</Grid>
												<Box my={2} mt={5}>
													<div className={classes.groupButtonSubmit}>
														<div className='left-button'>
															<div className={classes.wrapper}>
																<Button
																	className={classes.styleInputSearch}
																	style={{
																		marginRight: '10px',
																	}}
																	color='primary'
																	disabled={
																		statusCreate === STATUS_API.PENDING ||
																		statusEdit === STATUS_API.PENDING
																	}
																	size='large'
																	type='submit'
																	variant='contained'>
																	{sendData.type === ACTION_TABLE.CREATE
																		? 'Tạo mới'
																		: 'Cập nhật'}
																	{(statusCreate === STATUS_API.PENDING ||
																		statusEdit === STATUS_API.PENDING) && (
																		<div
																			style={{
																				marginLeft: 20,
																			}}>
																			<CircularProgress
																				color={'secondary'}
																				size={20}
																			/>
																		</div>
																	)}
																</Button>
															</div>
															<Button
																size='large'
																variant='contained'
																onClick={handleClose}>
																Thoát
															</Button>
														</div>
													</div>
												</Box>
											</form>
										)}
									</Formik>
								</CardContent>
								<Divider />
							</Card>
						</Grid>
					</Grid>
				</Container>
			</Dialog>
			{isSubmit &&
				(statusEdit === STATUS_API.ERROR ||
					statusEdit === STATUS_API.SUCCESS) && (
					<ToastMessage
						callBack={() => dispatch(clearMsg())}
						message={
							statusEdit === STATUS_API.SUCCESS
								? MESSAGE.UPDATE_DEVICE_SUCCESS
								: MESSAGE.UPDATE_DEVICE_FAIL
						}
						type={
							statusEdit === STATUS_API.SUCCESS
								? messageToastType_const.success
								: messageToastType_const.error
						}
					/>
				)}
			{isSubmit &&
				(statusCreate === STATUS_API.ERROR ||
					statusCreate === STATUS_API.SUCCESS) && (
					<ToastMessage
						callBack={() => dispatch(clearMsg())}
						message={
							statusCreate === STATUS_API.SUCCESS
								? MESSAGE.CREATE_DEVICE_SUCCESS
								: MESSAGE.CREATE_DEVICE_FAIL
						}
						type={
							statusCreate === STATUS_API.SUCCESS
								? messageToastType_const.success
								: messageToastType_const.error
						}
					/>
				)}
		</>
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
}))

export default FormEditDevice
