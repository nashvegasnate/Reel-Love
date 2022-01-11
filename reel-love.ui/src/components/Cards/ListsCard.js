import React, { useState } from 'react';
import {
  CardBody,
  CardTitle,
  Button
} from 'reactstrap';
import PropTypes from 'prop-types';
import { deleteList } from '../../helpers/data/listsData';
import ListForm from '../Forms/ListForm';

function ListsCard({
  list,
  id,
  user,
  setLists
}) {

  const [editing, setEditing] = useState(false);

  const handleClick = (type) => {
    switch (type) {
      case 'delete':
        deleteList(id).then((listsArray) => setLists(listsArray));
        break;
      case 'edit':
        setEditing((prevState) => !prevState);
        break;
      default:
        console.warn('default');
        break;
    }
  };
  return (
    <div>
      <div className='list-cards'>
        <CardBody>
          <CardTitle tag="h3">List Name: {list?.listName}</CardTitle>
          <Button
            className="btn-md mr-2 ml-2 mt-2"
            color="info"
            onClick={() => handleClick('edit')}
            size="sm">
            {editing ? 'Close Form' : 'Edit List' }
          </Button>
          <Button
            className="btn-md mr-2 ml-2 mt-2"
            color="danger"
            onClick={() => handleClick('delete')}
            size="sm">Delete
          </Button>
            {editing && <ListForm
                          id={list.id}
                          listName={list.listName}
                          setLists={setLists}
                          //listId={listId}
                          user={user}
                          formTitle='Edit List'
                        />
            }
        </CardBody>
      </div>
    </div>
  )
};

ListsCard.propTypes = {
  id: PropTypes.string.isRequired,
  listName: PropTypes.string.isRequired,
  setLists: PropTypes.func,
  user: PropTypes.any,
  list: PropTypes.any
}

export default ListsCard;
