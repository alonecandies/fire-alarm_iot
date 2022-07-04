import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import CircularProgress from '@material-ui/core/CircularProgress';

const LoadingComponent = ({ content, style }) => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <div className={classes.spiner}>
        <CircularProgress className={classes.spiner} color="inherit" />
      </div>
    </div>
  );
};

const useStyles = makeStyles(theme => ({
    root: {
      width: '100%',
      height: '100vh',
      position: 'relative',
      background: '#80808026',
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      pointerEvents: 'none'
    },
    spiner: {
      width: '90px !important',
      height: '90px !important'
    }
  }));


export default LoadingComponent;
