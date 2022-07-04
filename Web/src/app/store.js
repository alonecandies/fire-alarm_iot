import { configureStore } from '@reduxjs/toolkit'
import authSlice from '../features/authSlice'
import deviceSlice from '../features/deviceSlice'
import uiSlice from '../features/uiSlice'
import locationSlice from '../features/locationSlice'
import phoneSlice from 'src/features/phoneSlice'

export default configureStore({
	reducer: {
		authSlice: authSlice,
		deviceSlice: deviceSlice,
		uiSlice: uiSlice,
		locationSlice: locationSlice,
		phoneSlice: phoneSlice,
	},
})
