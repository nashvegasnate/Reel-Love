import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {
  Button,
  FormGroup,
  Form,
  Input,
  Label
} from 'reactstrap';
import { createList } from '../../helpers/data/listsData';
import { useHistory } from 'react-router-dom';


export default function ListForm({ user, formTitle, setLists }) {
  const [list, setList] = useState({
    listName: '',
    // uid: user.uid
  });

  const history = useHistory();

  //   // WHEN USING INPUTS, NEED FUNCTION THAT TRACKS CHANGES A USER MAKES:
  const handleInputChange = (e) => {
    setList((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value
    }));
  };

  // const handleSubmit = (e) => {
  //   e.preventDefault();
  //   createList(list, user.uid).then(setLists);
  // };
  const handleSubmit = (e) => {
    e.preventDefault();
    createList(list).then((listsArray) => setLists(listsArray));
    history.push('/myListsView');
  };

  return (
    <div className='list-form-container'>
      <Form id='add-list-form'
        autoComplete='off'
      >
        <h1>{formTitle}</h1>
        <FormGroup>
        <Label>List Title: </Label>
        <Input
          name='listName'
          type='text'
          placeholder='Name of List'
          value={list.listName}
          onChange={handleInputChange}
        />
          </FormGroup>
        <Button color="danger" type='submit' onClick={handleSubmit} className='mt-4'>Submit</Button>
      </Form>
    </div>
  );
}

ListForm.propTypes = {
  user: PropTypes.any,
  formTitle: PropTypes.string.isRequired,
  setLists: PropTypes.func.isRequired,
};
