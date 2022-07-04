import { createSlice } from '@reduxjs/toolkit'
import { API_GET_TYPE, STATUS_API } from 'src/app/constant/config'
import ApiAdapter from './apiAdapter'
import Cookie from 'js-cookie'

export const Login = ApiAdapter.PostHttp('authSlice/login', '/User')

export const Checktoken = ApiAdapter.GetHttp(
	'authSlice/checkToken',
	'/Authen',
	API_GET_TYPE.ALL
)

export const authSlice = createSlice({
	name: 'authSlice',
	initialState: {
		err: null,
		status: null,
		dataLogin: null,

		isValidtoken: false,
		statusCheck: null,
	},
	reducers: {
		logOutAction: state => {
			state.isLogin = false
			state.dataLogin = null
			localStorage.removeItem('access-token')
		},
	},
	extraReducers: {
		[Login.pending]: state => {
			state.status = STATUS_API.PENDING
			state.err = null
			state.dataLogin = null
		},
		[Login.fulfilled]: (state, action) => {
			state.status = STATUS_API.SUCCESS
			state.dataLogin = action.payload.data
			Cookie.set('token', action.payload.token)
		},
		[Login.rejected]: (state, action) => {
			state.status = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[Checktoken.pending]: state => {
			state.err = null
			state.isValidtoken = false
			state.statusCheck = STATUS_API.PENDING
		},
		[Checktoken.fulfilled]: state => {
			state.isValidtoken = true
			state.statusCheck = STATUS_API.SUCCESS
		},
		[Checktoken.rejected]: state => {
			state.isValidtoken = false
			state.statusCheck = STATUS_API.ERROR
		},
	},
})
export const { logOutAction } = authSlice.actions

export default authSlice.reducer
