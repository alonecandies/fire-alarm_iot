import { createSlice } from '@reduxjs/toolkit'
import { API_GET_TYPE, STATUS_API } from 'src/app/constant/config'
import ApiAdapter from './apiAdapter'
import Cookie from 'js-cookie'

export const CreatePhone = ApiAdapter.PostHttp('phoneSlice/Create', '/Phone')
export const EditPhone = ApiAdapter.PutHttp('phoneSlice/Edit', '/Phone')
export const DeletePhone = ApiAdapter.DeleteHttp('phoneSlice/Delete', '/Phone')

export const phoneSlice = createSlice({
	name: 'phoneSlice',
	initialState: {
		err: null,
		listContact: null,
		statusCreate: null,
		statusEdit: null,
		statusDelete: null,
	},
	reducers: {},
	extraReducers: {
		[CreatePhone.pending]: state => {
			state.statusCreate = STATUS_API.PENDING
			state.err = null
		},
		[CreatePhone.fulfilled]: (state, action) => {
			state.statusCreate = STATUS_API.SUCCESS
			state.listContact = [...action.payload.data, state.listContact]
		},
		[CreatePhone.rejected]: (state, action) => {
			state.statusCreate = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
		[EditPhone.pending]: state => {
			state.statusEdit = STATUS_API.PENDING
			state.err = null
		},
		[EditPhone.fulfilled]: (state, action) => {
			state.statusEdit = STATUS_API.SUCCESS
			state.listContact = state.listContact(item => {
				if (item.id === action.payload.id) item = action.payload
				return item
			})
		},
		[EditPhone.rejected]: (state, action) => {
			state.statusEdit = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},

		[DeletePhone.pending]: state => {
			state.statusDelete = STATUS_API.PENDING
			state.err = null
		},
		[DeletePhone.fulfilled]: (state, action) => {
			state.statusDelete = STATUS_API.SUCCESS
			let index = state.listContact.findIndex(
				item => item.id === action.payload
			)
			state.listContact.slice(index, index + 1)
		},
		[DeletePhone.rejected]: (state, action) => {
			state.statusDelete = STATUS_API.ERROR
			state.err = action.payload?.msg || action.error?.message
		},
	},
})

export default phoneSlice.reducer
