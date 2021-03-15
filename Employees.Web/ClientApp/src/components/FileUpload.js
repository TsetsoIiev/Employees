import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import CloudUploadIcon from '@material-ui/icons/CloudUpload';

const useStyles = makeStyles((theme) => ({
    root: {
        '& > *': {
            margin: theme.spacing(1),
        },
    },
    input: {
        display: 'none',
    },
}));

export default function FileUpload({ uploadFileHandler }) {
    const classes = useStyles();

    const uploadButtonHandler = (event) => {
        uploadFileHandler(event.target.files[0]);
    }

    return (
        <div className={classes.root}>
            <input
                accept="image/*"
                className={classes.input}
                id="contained-button-file"
                type="file"
                onChange={uploadButtonHandler}
            />
            <label htmlFor="contained-button-file">
                <Button
                    variant="contained"
                    color="primary"
                    component="span"
                    startIcon={<CloudUploadIcon />}
                >
                    Upload
                </Button>
            </label>
        </div>
    )
}