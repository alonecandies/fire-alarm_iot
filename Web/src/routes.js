import React from 'react'
import { Navigate } from 'react-router-dom'
import DashboardLayout from 'src/app/layouts/DashboardLayout'
import MainLayout from 'src/app/layouts/MainLayout'
import LoginView from 'src/app/views/auth/LoginView'
import NotFoundView from './app/views/errors/NotFoundView'
import DraftPageView from './app/views/errors/DraftPageView'
import DeviceView from './app/views/device'
import LocationView from './app/views/location'

const routes = [
	{
		path: 'app',
		element: <DashboardLayout />,
		children: [
			{ path: 'device', element: <DeviceView /> },
			{ path: 'location', element: <LocationView /> },
			// {
			//   path: 'tour',
			//   children: [
			//     { path: 'list', element: <TourView /> },
			//     { path: 'service', element: <ServiceView /> },
			//   ]
			// },
			{ path: '*', element: <Navigate to='/app/device' /> },
		],
	},
	{
		path: '/',
		element: <MainLayout />,
		children: [
			{ path: 'login', element: <LoginView /> },
			{ path: '404', element: <NotFoundView /> },
			{ path: 'waiting-confirm', element: <DraftPageView /> },
			{ path: '/', element: <Navigate to='/login' /> },
			{ path: '*', element: <Navigate to='/404' /> },
		],
	},
]

export default routes
