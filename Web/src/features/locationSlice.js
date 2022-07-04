import { createSlice } from '@reduxjs/toolkit'
import { API_GET_TYPE, STATUS_API } from 'src/app/constant/config'
import ApiAdapter from './apiAdapter'

export const GetAllLocation = ApiAdapter.GetHttp(
	'locationSlice/GetAll',
	'/Location',
	API_GET_TYPE.ALL
)
export const CreateLocation = ApiAdapter.PostHttp(
	'locationSlice/Create',
	'/Location'
)
export const EditLocation = ApiAdapter.PutHttp(
	'locationSlice/Edit',
	'/Location/'
)
export const locationSlice = createSlice({
	name: 'locationSlice',
	initialState: {
		err: null,
		statusGetAll: null,
		listLocation: null,

		statusCreate: null,
		statusEdit: null,
	},
	reducers: {
		clearMSg: state => {
			state.err = null
		},
	},
	extraReducers: {
		[GetAllLocation.pending]: state => {
			state.statusGetAll = STATUS_API.PENDING
			state.err = null
			state.listLocation = null
		},
		[GetAllLocation.fulfilled]: (state, action) => {
			state.statusGetAll = STATUS_API.SUCCESS
			state.listLocation = action.payload
		},
		[GetAllLocation.rejected]: (state, action) => {
			state.statusGetAll = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[CreateLocation.pending]: state => {
			state.statusCreate = STATUS_API.PENDING
			state.err = null
		},
		[CreateLocation.fulfilled]: (state, action) => {
			state.statusCreate = STATUS_API.SUCCESS
			state.listLocation = [action.payload, ...state.listLocation]
		},
		[CreateLocation.rejected]: (state, action) => {
			state.statusCreate = STATUS_API.ERROR
			state.err = 'Địa điểm đã tồn tại' || action.error?.message
		},
		[EditLocation.pending]: state => {
			state.statusEdit = STATUS_API.PENDING
			state.err = null
		},
		[EditLocation.fulfilled]: (state, action) => {
			state.statusEdit = STATUS_API.SUCCESS
			state.listLocation = state.listLocation.map(item => {
				if (item.id === action.payload.id) item = action.payload
				return item
			})
		},
		[EditLocation.rejected]: (state, action) => {
			state.statusEdit = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
	},
})
export const { clearMSg } = locationSlice.actions

export default locationSlice.reducer
