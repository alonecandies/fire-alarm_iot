import axios from 'axios'
import { createAsyncThunk } from '@reduxjs/toolkit'
import Cookie from 'js-cookie'
import { API_GET_TYPE } from '../app/constant/config'
class ApiAdapter {
	static PostHttp(nameSlice, url) {
		return createAsyncThunk(
			`${nameSlice}`,
			(payload, { rejectWithValue }) => {
				return new Promise((resolve, reject) => {
					axios({
						url: process.env.REACT_APP_BACKEND_URL + url,
						method: 'POST',
						headers: {
							'Access-Control-Allow-Origin': true,
							'Content-Type': 'application/json; charset=utf-8',
							token: Cookie.get('token'),
						},
						data: payload,
					})
						.then(res => resolve(res.data))
						.catch(err => {
							console.log(err)
							if (!err.response) reject(err)
							reject(rejectWithValue(err.response?.data))
						})
				})
			}
		)
	}
	static PutHttp(nameSlice, url) {
		return createAsyncThunk(
			`${nameSlice}`,
			(payload, { rejectWithValue }) => {
				return new Promise((resolve, reject) => {
					axios({
						url:
							process.env.REACT_APP_BACKEND_URL +
							url +
							payload.id,
						method: 'PUT',
						headers: {
							'Access-Control-Allow-Origin': true,
							'Content-Type': 'application/json; charset=utf-8',
							token: Cookie.get('token'),
						},
						data: payload,
					})
						.then(res => resolve(res.data))
						.catch(err => {
							console.log(err)
							if (!err.response) reject(err)
							reject(rejectWithValue(err.response?.data))
						})
				})
			}
		)
	}
	static GetHttp(nameSlice, url, type) {
		return createAsyncThunk(nameSlice, (payload, { rejectWithValue }) => {
			return new Promise((resolve, reject) => {
				let tmp = ''
				if (type === API_GET_TYPE.ALL) {
					tmp = process.env.REACT_APP_BACKEND_URL + url
				} else
					tmp = process.env.REACT_APP_BACKEND_URL + url + payload.id
				axios({
					url: tmp,
					method: 'GET',
					headers: {
						'Access-Control-Allow-Origin': true,
						'Content-Type': 'application/json; charset=utf-8',
						token: Cookie.get('token'),
					},
				})
					.then(res => resolve(res.data))
					.catch(err => {
						console.log(err)
						if (!err.response) reject(err)
						reject(rejectWithValue(err.response?.data))
					})
			})
		})
	}
	static DeleteHttp(nameSlice, url) {
		return createAsyncThunk(nameSlice, (payload, { rejectWithValue }) => {
			return new Promise((resolve, reject) => {
				axios({
					url: process.env.REACT_APP_BACKEND_URL + url,
					method: 'Delete',
					headers: {
						'Access-Control-Allow-Origin': true,
						'Content-Type': 'application/json; charset=utf-8',
						token: Cookie.get('token'),
					},
				})
					.then(res => resolve(payload.id))
					.catch(err => {
						console.log(err)
						if (!err.response) reject(err)
						reject(rejectWithValue(err.response?.data))
					})
			})
		})
	}
}
export default ApiAdapter
