import React from 'react';
import SignalCellularConnectedNoInternet0BarIcon from '@material-ui/icons/SignalCellularConnectedNoInternet0Bar';
import Typography from '@material-ui/core/Typography';

function NullData(props) {
  return (
    <div style = { { width:'100%', padding:20 , textAlign:'center' , fontSize:28} } >
      <SignalCellularConnectedNoInternet0BarIcon style={{fontSize:50}}/>
      <Typography variant={'caption'} >Chưa có dữ liệu</Typography>
    </div>
  );
}

export default NullData;
