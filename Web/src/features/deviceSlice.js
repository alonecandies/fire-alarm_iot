import { createSlice } from '@reduxjs/toolkit'
import ApiAdapter from './apiAdapter'
import { API_GET_TYPE, STATUS_API } from '../app/constant/config'

export const getAllDevice = ApiAdapter.GetHttp(
	'deviceSlice/getAll',
	'/Device',
	API_GET_TYPE.ALL
)
export const getDetailDevice = ApiAdapter.GetHttp(
	'deviceSlice/getDetail',
	'/Device/Status/',
	API_GET_TYPE.DETAIL
)
export const getDeviceByLocationId = ApiAdapter.GetHttp(
	'deviceSlice/getDeviceByLocationId',
	'/Device/Location/',
	API_GET_TYPE.DETAIL
)
export const getDataDevice = ApiAdapter.GetHttp(
	'deviceSlice/getDeviceStatus',
	'/Record/',
	API_GET_TYPE.DETAIL
)
export const editDevice = ApiAdapter.PutHttp(
	'deviceSlice/editDevice',
	'/Device/'
)
export const createDevice = ApiAdapter.PostHttp(
	'deviceSlice/Create',
	'/Device/'
)
export const getPhoneByDevice = ApiAdapter.GetHttp(
	'deviceSlice/getPhoneContact',
	'/Phone/',
	API_GET_TYPE.DETAIL
)

export const deviceSlice = createSlice({
	name: 'deviceSlice',
	initialState: {
		err: null,
		statusGetAll: null,
		listDevice: null,

		statusGetDetail: null,
		detailDevice: null,

		statusGetByLocation: null,
		locationId: null,

		listData: null,
		statusGetData: null,

		statusEdit: null,
		statusCreate: null,

		statusGetDataContact: null,
		listDataContact: null,
	},
	reducers: {
		setPageId: (state, action) => {
			state.currentPageId = action.payload
		},
		setImageId: (state, action) => {
			state.currentImageId = action.payload
		},
		clearMsg: state => {
			state.err = null
		},
	},
	extraReducers: {
		[getAllDevice.pending]: state => {
			state.statusGetAll = STATUS_API.PENDING
			state.listDevice = null
			state.err = null
		},
		[getAllDevice.fulfilled]: (state, action) => {
			state.statusGetAll = STATUS_API.SUCCESS
			state.listDevice = action.payload.filter(item => item.is_off === false)
		},
		[getAllDevice.rejected]: (state, action) => {
			state.statusGetAll = STATUS_API.ERROR
			state.err = state.err = action.payload?.msg || action.error?.message
		},
		[getDetailDevice.pending]: state => {
			state.statusGetDetail = STATUS_API.PENDING
			state.detailDevice = null
			state.err = null
		},
		[getDetailDevice.fulfilled]: (state, action) => {
			state.statusGetDetail = STATUS_API.SUCCESS
			state.detailDevice = action.payload[0]
		},
		[getDetailDevice.rejected]: (state, action) => {
			state.statusGetDetail = STATUS_API.ERROR
			state.err = state.err = action.payload?.msg || action.error?.message
		},
		[getDeviceByLocationId.pending]: (state, action) => {
			console.log(action.meta.arg.id)
			state.statusGetByLocation = STATUS_API.PENDING
			// state.locationId = action.payload.id
			state.err = null
			state.listDevice = null
		},
		[getDeviceByLocationId.fulfilled]: (state, action) => {
			state.statusGetByLocation = STATUS_API.SUCCESS
			state.listDevice = action.payload
		},
		[getDeviceByLocationId.rejected]: (state, action) => {
			state.statusGetByLocation = STATUS_API.ERROR
			state.err = state.err = action.payload?.msg || action.error?.message
		},
		[getDataDevice.pending]: state => {
			state.statusGetData = STATUS_API.PENDING
			state.listData = null
			state.err = null
		},
		[getDataDevice.rejected]: (state, action) => {
			state.statusGetData = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[getDataDevice.fulfilled]: (state, action) => {
			state.statusGetData = STATUS_API.SUCCESS
			state.listData = action.payload
		},
		[editDevice.pending]: (state, action) => {
			state.statusEdit = STATUS_API.PENDING
			state.statusCreate = null
			state.err = null
		},
		[editDevice.rejected]: (state, action) => {
			state.statusEdit = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[editDevice.fulfilled]: (state, action) => {
			state.statusEdit = STATUS_API.SUCCESS
			let idEdited = action.payload.id
			state.listDevice = state.listDevice.map(item => {
				if (item.id === idEdited) item = action.payload
				return item
			})
		},
		[createDevice.pending]: (state, action) => {
			state.statusCreate = STATUS_API.PENDING
			state.statusEdit = null
			state.err = null
		},
		[createDevice.rejected]: (state, action) => {
			state.statusCreate = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[createDevice.fulfilled]: (state, action) => {
			state.statusCreate = STATUS_API.SUCCESS
			state.listDevice.unshift(action.payload)
		},
		[getPhoneByDevice.pending]: state => {
			state.statusGetDataContact = STATUS_API.PENDING
			state.err = null
			state.listDataContact = null
		},
		[getPhoneByDevice.rejected]: (state, action) => {
			state.statusGetDataContact = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[getPhoneByDevice.fulfilled]: (state, action) => {
			state.statusGetDataContact = STATUS_API.SUCCESS
			state.listDataContact = action.payload
		},
	},
})
export const { setImageId, setPageId, clearMsg } = deviceSlice.actions

export default deviceSlice.reducer
