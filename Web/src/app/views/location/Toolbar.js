import React, { useState } from 'react'
import PropTypes from 'prop-types'
import { Search as SearchIcon } from 'react-feather'
import CircularProgress from '@material-ui/core/CircularProgress'
import clsx from 'clsx'
import {
	Box,
	Button,
	Card,
	CardContent,
	InputAdornment,
	makeStyles,
	SvgIcon,
	TextField,
} from '@material-ui/core'
import { green } from '@material-ui/core/colors'
import Typography from '@material-ui/core/Typography'

const Toolbar = ({ className, createRef, searchRef, isLoading, ...rest }) => {
	const classes = useStyles()
	const [query, setQuery] = useState({ name: '' })

	const onEnterSearchInput = event => {
		if (!searchRef) return
		if (event.keyCode == 13) {
			const queryValue = Object.assign({}, query, {
				name: event.target.value,
				page: 1,
			})
			setQuery(queryValue)
			searchRef(queryValue)
		}
	}

	const changeTextInputSearch = event => {
		const queryValue = Object.assign({}, query, {
			name: event.target.value,
			page: 1,
		})
		setQuery(queryValue)
	}

	const clearSearch = () => {
		const queryValue = Object.assign({}, query, { name: '' })
		setQuery(queryValue)
		searchRef(queryValue)
	}

	const searchLocation = () => {
		if (!searchRef) return
		searchRef(query)
	}

	return (
		<div className={clsx(classes.root, className)} {...rest}>
			<Box>
				<Card>
					<CardContent>
						<Box className={classes.groupSearch}>
							{/*<div className={classes.groupSearch}>*/}
							{/*	<TextField*/}
							{/*		onKeyDown={onEnterSearchInput}*/}
							{/*		onChange={changeTextInputSearch}*/}
							{/*		className={classes.searchInput}*/}
							{/*		value={query.name}*/}
							{/*		InputProps={{*/}
							{/*			startAdornment: (*/}
							{/*				<InputAdornment position='start'>*/}
							{/*					<SvgIcon*/}
							{/*						fontSize='small'*/}
							{/*						color='action'>*/}
							{/*						<SearchIcon />*/}
							{/*					</SvgIcon>*/}
							{/*				</InputAdornment>*/}
							{/*			),*/}
							{/*		}}*/}
							{/*		placeholder='Tìm kiếm theo địa điểm'*/}
							{/*		variant='outlined'*/}
							{/*	/>*/}
							{/*	<div className={classes.wrapper}>*/}
							{/*		<Button*/}
							{/*			className={classes.styleInputSearch}*/}
							{/*			color='primary'*/}
							{/*			variant='contained'*/}
							{/*			onClick={() => searchLocation()}>*/}
							{/*			{!isLoading ? (*/}
							{/*				<span>Tìm kiếm </span>*/}
							{/*			) : (*/}
							{/*				''*/}
							{/*			)}*/}
							{/*		</Button>*/}
							{/*		{isLoading && (*/}
							{/*			<CircularProgress*/}
							{/*				size={24}*/}
							{/*				className={classes.buttonProgress}*/}
							{/*			/>*/}
							{/*		)}*/}
							{/*	</div>*/}
							{/*	<Button*/}
							{/*		className={classes.styleInputSearch}*/}
							{/*		color='inherit'*/}
							{/*		variant='contained'*/}
							{/*		onClick={clearSearch}>*/}
							{/*		Bỏ Lọc*/}
							{/*	</Button>*/}
							{/*</div>*/}
							<div>
								<Button
									onClick={() => createRef()}
									size={'large'}
									variant={'contained'}
									color={'secondary'}>
									Tạo mới
								</Button>
							</div>
						</Box>
					</CardContent>
				</Card>
			</Box>
		</div>
	)
}

Toolbar.propTypes = {
	className: PropTypes.string,
}

const useStyles = makeStyles(theme => ({
	root: {},
	importButton: {
		marginRight: theme.spacing(1),
	},
	wrapper: {
		margin: theme.spacing(1),
		position: 'relative',
	},
	formControl: {
		margin: theme.spacing(1),
		minWidth: 120,
	},
	buttonProgress: {
		color: green[500],
		position: 'absolute',
		top: '50%',
		left: '50%',
		marginTop: -12,
		marginLeft: -12,
	},
	exportButton: {
		marginRight: theme.spacing(1),
	},
	groupSearch: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'space-between',
	},
	searchInput: {
		width: '400px',
	},
	styleInputSearch: {
		height: '55px',
	},
}))

export default Toolbar
