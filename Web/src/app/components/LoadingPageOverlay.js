import React from 'react';
import Backdrop from '@material-ui/core/Backdrop';
import CircularProgress from '@material-ui/core/CircularProgress';
import { makeStyles } from '@material-ui/core/styles';
import { useSelector } from 'react-redux';

const useStyles = makeStyles((theme) => ({
  backdrop: {
    zIndex: theme.zIndex.drawer + 1,
    color: '#fff',
  },
}));

export default function LoadingPageOverLay() {
  const classes = useStyles();
  const show = useSelector(state=>state.uiSlice.isShowPageLoading);

  return (
    <div>
      <Backdrop className={classes.backdrop} open={show} >
        <CircularProgress color="inherit" />
      </Backdrop>
    </div>
  );
}
