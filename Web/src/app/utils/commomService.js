
import { saveAs } from 'file-saver';

export function currencyFormat(num) {
  num = Number.parseInt(num);
  return num.toFixed(0).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + ' VNĐ';
}
export const ArrUtil = {
  removeElmByValue : (value , arr)=>{
    let index = arr.indexOf(value)
    if (index > -1) {
      arr.splice(index, 1);
    }
    else return false
  }
}

export function convertDateTimeContract(date){
  const d = new Date(date);
  const dateValue = date.split('T')[0];
  const hourValue = `${formatTime(d.getHours())}:${formatTime(d.getMinutes())}`;
  const result = `${dateValue}T${hourValue}`;
  return result;
}

function formatTime(time){
  time = time.toString();
  if(time.length <= 1) time = `0${time}`;
  return time;
}
export function convertDateTimeToString(date){
  const dateValue = date.split('T')[0];
  return dateValue;
}


export function ExportDownloadFile(filename, data) {
  const blob = b64toBlob(data, 'application/pdf');
  const file = new Blob([blob]);
  saveAs(file, filename);
}

const b64toBlob = (b64Data, contentType='', sliceSize=512) => {
  const byteCharacters = atob(b64Data);
  const byteArrays = [];

  for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
    const slice = byteCharacters.slice(offset, offset + sliceSize);

    const byteNumbers = new Array(slice.length);
    for (let i = 0; i < slice.length; i++) {
      byteNumbers[i] = slice.charCodeAt(i);
    }

    const byteArray = new Uint8Array(byteNumbers);
    byteArrays.push(byteArray);
  }

  const blob = new Blob(byteArrays, {type: contentType});
  return blob;
}

export function playAudioNotification(){
  const audio = new Audio();
  audio.src = 'https://mp3.fastupload.co/data/1620936062/sound-chat.mp3';
  audio.load();
  audio.play();
  //https://mp3.fastupload.co/files/1620936062
}
