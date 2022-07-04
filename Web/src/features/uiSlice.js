import { createSlice } from '@reduxjs/toolkit';

export const uiSlice = createSlice({
  name: 'uiSlice',
  initialState: {
    isShowConfirm: false,
    isShowToast: false,
    isShowPageLoading: false

  },
  reducers: {
    showDialogConfirm: (state) => {
      state.isShowConfirm = true;
    },
    closeDialogConfirm: state => {
      state.isShowConfirm = false;
    },
    showToast: (state) => {
      state.isShowToast = true;
    },
    closeToast: (state) => {
      state.isShowToast = false
    },
    showPageLoading: (state) => {
      state.isShowPageLoading = true
    },
    closePageLoading: (state) => {
      state.isShowPageLoading = false
    }
  }

});
export const {
  showDialogConfirm, closeDialogConfirm, showToast, closeToast, showPageLoading, closePageLoading
} = uiSlice.actions;


export default uiSlice.reducer;
