import React, { useCallback, useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Box, Container, makeStyles } from '@material-ui/core'

import Page from 'src/app/components/Page'
import Results from './Results'
import {
	getAllDevice,
	getDeviceByLocationId,
} from '../../../features/deviceSlice'
import { ACTION_TABLE, STATUS_API } from '../../constant/config'
import Toolbar from './Toolbar'
import DetailsDevice from './DeviceDetail'
import FormEditDevice from './DeviceDetail/FormEditDevice'
import { GetAllLocation } from '../../../features/locationSlice'

const useStyles = makeStyles(theme => ({
	root: {
		backgroundColor: theme.palette.background.dark,
		minHeight: '100%',
		paddingBottom: theme.spacing(3),
		paddingTop: theme.spacing(3),
	},
}))

const DeviceView = () => {
	const classes = useStyles()
	const dispatch = useDispatch()

	const listDevice = useSelector(state => state.deviceSlice.listDevice)
	const statusGetAll = useSelector(state => state.deviceSlice.statusGetAll)
	const err = useSelector(state => state.deviceSlice.err)
	const statusGetAllLocation = useSelector(
		state => state.locationSlice.statusGetAll
	)
	const listLocation = useSelector(state => state.locationSlice.listLocation)

	const [isShowModalDeviceDetails, setShowModalDetail] = React.useState(false)
	const [isShowModalCreateUpdate, setShowModalCreateUpdate] = React.useState(
		false
	)
	const [sendData, setSendData] = React.useState({
		type: null,
		data: null,
	})
	const onEditDevice = data => {
		setShowModalCreateUpdate(true)
		setSendData(data)
	}
	const onCreateDevice = () => {
		setShowModalCreateUpdate(true)
		setSendData({
			type: ACTION_TABLE.CREATE,
			data: {},
		})
	}
	const showDetailsDevice = data => {
		setShowModalDetail(true)
		setSendData(data)
	}
	const closeModalDeviceDetails = () => {
		setShowModalDetail(false)
	}
	const GetListDeviceByLocationId = locationId => {
		if (!locationId) dispatch(getAllDevice())
		else {
			let payload = { id: locationId }
			dispatch(getDeviceByLocationId(payload))
		}
	}
	useEffect(() => {
		dispatch(getAllDevice())
	}, [dispatch])
	useEffect(() => {
		dispatch(GetAllLocation())
	}, [dispatch])
	return (
		<Page className={classes.root} title='Thiết bị '>
			<Container maxWidth={false}>
				<React.Fragment>
					<Toolbar
						searchRef={GetListDeviceByLocationId}
						onCreateDevice={onCreateDevice}
						data={listLocation}
						isLoading={statusGetAllLocation === STATUS_API.PENDING}
					/>
					<Box mt={3}>
						<Results
							actionDetailsDeviceRef={showDetailsDevice}
							deviceData={listDevice}
							isLoading={statusGetAll === STATUS_API.PENDING}
							actionEditDevice={onEditDevice}
							err={err}
						/>
					</Box>
				</React.Fragment>
			</Container>
			{isShowModalDeviceDetails && sendData && (
				<DetailsDevice
					open={isShowModalDeviceDetails}
					sendData={sendData}
					closeRef={closeModalDeviceDetails}
				/>
			)}
			{isShowModalCreateUpdate && sendData && (
				<FormEditDevice
					open={isShowModalCreateUpdate}
					sendData={sendData}
					locationData={listLocation}
					isLoadingLocation={statusGetAllLocation === STATUS_API.PENDING}
					closeRef={() => setShowModalCreateUpdate(false)}
				/>
			)}
			{/*<DialogConfirm*/}
			{/*  title={isDeleteRootCate?MESSAGE.CONFIRM_DELETE_ROOT_CATEGORY: MESSAGE.CONFIRM_DELETE_CATEGORY}*/}
			{/*  textOk={MESSAGE.BTN_YES}*/}
			{/*  textCancel={MESSAGE.BTN_CANCEL}*/}
			{/*  callbackOk={() => confirmDeleteDevice()}*/}
			{/*  callbackCancel={() => dispatch(closeDialogConfirm())}*/}
			{/*/>*/}
			{/*{isChangeDeleteDevice && isDeleted ?(*/}
			{/*  <ToastMessage*/}
			{/*    callBack={() => dispatch(resetChangeUpdateDevice())}*/}
			{/*    message={*/}
			{/*      isChangeDeleteDevice == STATUS_API.SUCCESS*/}
			{/*        ? MESSAGE.DELETE_CATEGORY_SUCCESS*/}
			{/*        : MESSAGE.DELETE_CATEGORY_FAIL*/}
			{/*    }*/}
			{/*    type={*/}
			{/*      isChangeDeleteDevice == STATUS_API.SUCCESS*/}
			{/*        ? messageToastType_const.success*/}
			{/*        : messageToastType_const.error*/}
			{/*    }*/}
			{/*  />*/}
			{/*) : (*/}
			{/*  ''*/}
			{/*)}*/}
		</Page>
	)
}

export default DeviceView
