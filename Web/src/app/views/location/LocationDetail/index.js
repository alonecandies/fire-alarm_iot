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
import {
	clearMSg,
	CreateLocation,
	EditLocation,
} from '../../../../features/locationSlice'
import { MESSAGE } from '../../../constant/message'
import ToastMessage from '../../../components/ToastMessage'
import { showToast } from '../../../../features/uiSlice'

const Transition = React.forwardRef(function Transition(props, ref) {
	return <Slide direction='up' ref={ref} {...props} />
})
function DetailsLocation({ open, sendData, closeRef }) {
	const classes = useStyles()
	const dispatch = useDispatch()

	const handleClose = () => {
		if (!closeRef) return
		closeRef()
	}
	const statusCreate = useSelector(state => state.locationSlice.statusCreate)
	const statusEdit = useSelector(state => state.locationSlice.statusEdit)

	const [isSubmit, setIsSubmit] = React.useState(false)
	const handleSubmit = data => {
		setIsSubmit(true)
		let location = { ...data }

		if (sendData.type === ACTION_TABLE.CREATE) {
			delete location.id
			dispatch(CreateLocation(location))
		} else dispatch(EditLocation(location))
	}

	useEffect(() => {
		if (
			statusCreate !== STATUS_API.PENDING ||
			statusEdit !== STATUS_API.PENDING
		) {
			dispatch(showToast())
		}
	}, [statusEdit, statusCreate])
	return (
		<>
			<Dialog
				fullWidth
				maxWidth={'sm'}
				open={open}
				onClose={() => handleClose()}
				TransitionComponent={Transition}>
				<AppBar className={classes.appBar}>
					<ToolbarEdit
						closeToolbarRef={handleClose}
						type={sendData.type}
					/>
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
										initialValues={{
											id: sendData.data?.id || null,
											location_name:
												sendData.data?.location_name ||
												'',
										}}
										validationSchema={Yup.object().shape({
											location_name: Yup.string()
												.max(255)
												.required(
													'Tên địa điểm không được để trống'
												),
										})}
										onSubmit={handleSubmit}>
										{({
											errors,
											handleBlur,
											handleChange,
											handleSubmit,
											touched,
											values,
										}) => (
											<form onSubmit={handleSubmit}>
												<Grid container spacing={5}>
													<Grid item md={12} xs={12}>
														<TextField
															error={Boolean(
																touched.location_name &&
																	errors.location_name
															)}
															fullWidth
															helperText={
																touched.location_name &&
																errors.location_name
															}
															label='Tên Location'
															margin='normal'
															name='location_name'
															onBlur={handleBlur}
															onChange={
																handleChange
															}
															value={
																values.location_name
															}
															variant='outlined'
														/>
													</Grid>
												</Grid>
												<Box my={2} mt={5}>
													<div
														className={
															classes.groupButtonSubmit
														}>
														<div className='left-button'>
															<div
																className={
																	classes.wrapper
																}>
																<Button
																	className={
																		classes.styleInputSearch
																	}
																	style={{
																		marginRight:
																			'10px',
																	}}
																	color='primary'
																	disabled={
																		statusCreate ===
																			STATUS_API.PENDING ||
																		statusEdit ===
																			STATUS_API.PENDING
																	}
																	size='large'
																	type='submit'
																	variant='contained'>
																	{sendData.type ===
																	ACTION_TABLE.CREATE
																		? 'Tạo mới'
																		: 'Cập nhật'}
																	{(statusCreate ===
																		STATUS_API.PENDING ||
																		statusEdit ===
																			STATUS_API.PENDING) && (
																		<div
																			style={{
																				marginLeft: 20,
																			}}>
																			<CircularProgress
																				color={
																					'secondary'
																				}
																				size={
																					20
																				}
																			/>
																		</div>
																	)}
																</Button>
															</div>
															<Button
																size='large'
																variant='contained'
																onClick={
																	handleClose
																}>
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
						callBack={() => dispatch(clearMSg())}
						message={
							statusEdit === STATUS_API.SUCCESS
								? MESSAGE.EDIT_LOCATION_SUC
								: MESSAGE.EDIT_LOCATION_FAIL
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
						callBack={() => dispatch(clearMSg())}
						message={
							statusCreate === STATUS_API.SUCCESS
								? MESSAGE.CREATE_LOCATION_SUC
								: MESSAGE.CREATE_LOCATION_FAIL
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

export default DetailsLocation
