import React, { useState } from 'react';
import { readString } from 'react-papaparse';
import FileUpload from './FileUpload';
import EmployeeData from './EmployeeData';
import axios from 'axios';

export function Home() {

  const [fileData, setFileData] = useState([]);

  const uploadFileHandler = (file) => {
    if (file === undefined) return;

    const reader = new FileReader();
    reader.onload = () => {
      parseData(reader.result);
    }

    reader.readAsText(file);
  }

  const parseData = (data) => {
    const csvData = readString(data).data;
    const result = [];

    csvData.map(el => {
      result.push({
        employeeId: el[0],
        projectId: el[1],
        dateFrom: el[2],
        dateTo: el[3]
      });
    })

    setFileData(result);

    axios.post('/GetLongestCoworkers', result)
      .then(res => {
        if (res.status === 200) {
          alert(`
          First employee id: ${res.data.firstEmployeeId} 
          Second employee id: ${res.data.secondEmployeeId}
          Total days worked: ${res.data.totalDaysWorked} 
          Project ids worked on: ${res.data.projectIdsWorkedOn}`);
        } else {
          alert('Incorrect data')
        }
      });
  }

  return (
    <div>
      <FileUpload uploadFileHandler={uploadFileHandler} />

      {fileData.length ? (
        <EmployeeData data={fileData} />
      ) : (
        <p>Select a file to show details</p>
      )}
    </div>
  );
}