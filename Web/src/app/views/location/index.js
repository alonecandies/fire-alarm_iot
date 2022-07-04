import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Box, Container, makeStyles } from '@material-ui/core'

import Page from 'src/app/components/Page'
import Results from './Results'
import { GetAllLocation } from '../../../features/locationSlice'
import { ACTION_TABLE, STATUS_API } from '../../constant/config'
import Toolbar from './Toolbar'
import DetailsLocation from './LocationDetail'

const useStyles = makeStyles(theme => ({
	root: {
		backgroundColor: theme.palette.background.dark,
		minHeight: '100%',
		paddingBottom: theme.spacing(3),
		paddingTop: theme.spacing(3),
	},
}))

const LocationView = () => {
	const classes = useStyles()
	const dispatch = useDispatch()

	const listLocation = useSelector(state => state.locationSlice.listLocation)
	const statusGetAll = useSelector(state => state.locationSlice.statusGetAll)
	const err = useSelector(state => state.locationSlice.err)
	const [isShowModalLocationDetails, setIsShowModalLocation] = React.useState(
		false
	)
	const [sendData, setSendData] = React.useState({
		type: null,
		data: null,
	})
	const showDetailsLocation = data => {
		setIsShowModalLocation(true)
		setSendData(data)
	}
	const closeModalLocationDetails = () => {
		setIsShowModalLocation(false)
	}
	const createLocation = () => {
		setIsShowModalLocation(true)
		setSendData({ type: ACTION_TABLE.CREATE, data: {} })
	}
	useEffect(() => {
		dispatch(GetAllLocation())
	}, [dispatch])

	return (
		<Page className={classes.root} title='Trạm lắp đặt '>
			<Container maxWidth={false}>
				<React.Fragment>
					<Toolbar
						createRef={createLocation}
						// searchRef={GetListLocationWithParams}
					/>
					<Box mt={3}>
						<Results
							actionDetailsLocationRef={showDetailsLocation}
							locationData={listLocation}
							isLoading={statusGetAll === STATUS_API.PENDING}
							// createRef={createLocation}
							err={err}
						/>
					</Box>
				</React.Fragment>
			</Container>
			{isShowModalLocationDetails && (
				<DetailsLocation
					open={isShowModalLocationDetails}
					sendData={sendData}
					closeRef={closeModalLocationDetails}
				/>
			)}
		</Page>
	)
}

export default LocationView
