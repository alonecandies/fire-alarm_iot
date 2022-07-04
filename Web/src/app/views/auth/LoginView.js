import React from 'react'
import { useNavigate } from 'react-router-dom'
import * as Yup from 'yup'
import { Formik } from 'formik'
import {
	Box,
	Button,
	CircularProgress,
	Container,
	makeStyles,
	TextField,
	Typography,
} from '@material-ui/core'

import Page from 'src/app/components/Page'
import { Checktoken, Login } from '../../../features/authSlice'
import { STATUS_API } from 'src/app/constant/config'
import { useDispatch, useSelector } from 'react-redux'
import { useEffect } from 'react'
import Cookie from 'js-cookie'
const useStyles = makeStyles(theme => ({
	root: {
		backgroundColor: theme.palette.background.dark,
		height: '100%',
		paddingBottom: theme.spacing(3),
		paddingTop: theme.spacing(3),
	},
}))

const LoginView = () => {
	const classes = useStyles()
	const navigate = useNavigate()
	const statusApi = useSelector(state => state.authSlice.status)
	const statusApiCheck = useSelector(state => state.authSlice.statusCheck)
	const error = useSelector(state => state.authSlice.err)
	// const dataLogin = useSelector(state => state.authSlice.dataLogin)

	const [isSubmit, setSubmit] = React.useState(false)
	const dispatch = useDispatch()
	useEffect(() => {
		if (
			statusApi === STATUS_API.SUCCESS ||
			statusApiCheck === STATUS_API.SUCCESS
		) {
			navigate('/app/dashboard', { replace: true })
		}
	}, [statusApi, statusApiCheck, navigate])
	useEffect(() => {
		if (!isSubmit && Cookie.get('token')) {
			dispatch(Checktoken())
		}
	}, [dispatch, isSubmit])

	return (
		<Page className={classes.root} title='Đăng nhập'>
			<Box
				display='flex'
				flexDirection='column'
				height='100%'
				justifyContent='center'>
				<Container maxWidth='sm'>
					<Formik
						initialValues={{
							username: '',
							password: '',
						}}
						validationSchema={Yup.object().shape({
							username: Yup.string()
								.max(255)
								.required('Bạn cần nhập tên đăng nhập'),
							password: Yup.string()
								.max(255)
								.required('Bạn cần nhập mật khẩu'),
						})}
						onSubmit={values => {
							setSubmit(true)
							dispatch(Login(values))
						}}>
						{({
							errors,
							handleBlur,
							handleChange,
							handleSubmit,
							isSubmitting,
							touched,
							values,
						}) => (
							<form onSubmit={handleSubmit}>
								<Box mb={3}>
									<Typography
										color='textPrimary'
										variant='h1'>
										Trang đăng nhập
									</Typography>
									<br />
									<Typography
										color='textSecondary'
										gutterBottom
										variant='body2'>
										Xin chào đến với Huster OOAD
									</Typography>
								</Box>
								<TextField
									error={Boolean(
										touched.username && errors.username
									)}
									fullWidth
									helperText={
										touched.username && errors.username
									}
									label='Tên đăng nhập'
									margin='normal'
									name='username'
									onBlur={e => {
										handleBlur(e)
									}}
									onChange={e => {
										handleChange(e)
									}}
									type='text'
									value={values.username}
									variant='outlined'
								/>
								<TextField
									error={Boolean(
										touched.password && errors.password
									)}
									fullWidth
									helperText={
										touched.password && errors.password
									}
									label='Mật khẩu'
									margin='normal'
									name='password'
									onBlur={e => {
										handleBlur(e)
									}}
									onChange={e => {
										handleChange(e)
									}}
									type='password'
									value={values.password}
									variant='outlined'
								/>
								<Typography
									color={'error'}
									variant={'subtitle1'}
									align={'center'}>
									{isSubmit && error}
								</Typography>
								<Box my={2}>
									<Button
										color='primary'
										disabled={
											statusApi === STATUS_API.PENDING
										}
										fullWidth
										size='large'
										type='submit'
										variant='contained'>
										Đăng nhập
										{statusApi === STATUS_API.PENDING && (
											<div style={{ marginLeft: 20 }}>
												<CircularProgress
													color={'secondary'}
													size={20}
												/>
											</div>
										)}
									</Button>
								</Box>
							</form>
						)}
					</Formik>
				</Container>
			</Box>
		</Page>
	)
}

export default LoginView
