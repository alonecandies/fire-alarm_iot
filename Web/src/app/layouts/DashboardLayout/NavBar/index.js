import React, { useEffect } from 'react'
import { Link as RouterLink, useLocation } from 'react-router-dom'
import PropTypes from 'prop-types'
import {
	Avatar,
	Box,
	Chip,
	Divider,
	Drawer,
	Hidden,
	List,
	makeStyles,
	Typography,
} from '@material-ui/core'
import {
	BarChart as BarChartIcon,
	FileText as ContractIcon,
} from 'react-feather'
import NavItem from './NavItem'
import { useSelector } from 'react-redux'
import { roleName_const } from '../../../constant/config'

const useStyles = makeStyles(() => ({
	mobileDrawer: {
		width: 256,
	},
	desktopDrawer: {
		width: 256,
		top: 64,
		height: 'calc(100% - 64px)',
	},
	avatar: {
		cursor: 'pointer',
		width: 64,
		height: 64,
	},
	nested: {
		paddingLeft: 50,
	},
}))

const NavBar = ({ onMobileClose, openMobile }) => {
	const classes = useStyles()
	const location = useLocation()
	const dataLogin = useSelector(state => state.authSlice.dataLogin)

	useEffect(() => {
		if (openMobile && onMobileClose) {
			onMobileClose()
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, [location.pathname])

	const content = (
		<Box height='100%' display='flex' flexDirection='column'>
			<Box
				alignItems='center'
				display='flex'
				flexDirection='column'
				p={2}>
				<Avatar
					className={classes.purple}
					component={RouterLink}
					src={dataLogin?.avatar || '/static/images/no-avatar.png'}
					to='/app/account'
				/>

				<Typography
					className={classes.name}
					color='textPrimary'
					variant='h5'>
					user01
				</Typography>
				{/*<Typography*/}
				{/*	className={classes.name}*/}
				{/*	color='textPrimary'*/}
				{/*	variant='h5'>*/}
				{/*	<Chip*/}
				{/*		label={roleName_const[dataLogin?.role_id - 1] || 'None'}*/}
				{/*		size={'small'}*/}
				{/*		color={'primary'}*/}
				{/*	/>*/}
				{/*</Typography>*/}
			</Box>
			<Divider />
			<Box p={2}>
				<List>
					<NavItem
						href={'/app/device'}
						icon={BarChartIcon}
						title='Thiết bị'
					/>
					<NavItem
						href={'/app/location'}
						icon={ContractIcon}
						title='Trạm lắp đặt'
					/>
				</List>
			</Box>
			<Box flexGrow={1} />
		</Box>
	)

	return (
		<>
			<Hidden lgUp>
				<Drawer
					anchor='left'
					classes={{ paper: classes.mobileDrawer }}
					onClose={onMobileClose}
					open={openMobile}
					variant='temporary'>
					{content}
				</Drawer>
			</Hidden>
			<Hidden mdDown>
				<Drawer
					anchor='left'
					classes={{ paper: classes.desktopDrawer }}
					open
					variant='persistent'>
					{content}
				</Drawer>
			</Hidden>
		</>
	)
}

NavBar.propTypes = {
	onMobileClose: PropTypes.func,
	openMobile: PropTypes.bool,
}

NavBar.defaultProps = {
	onMobileClose: () => {},
	openMobile: false,
}

export default NavBar
