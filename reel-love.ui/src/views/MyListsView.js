import React, { useState, useEffect } from 'react';
import { Button } from 'reactstrap';
import getLists from '../helpers/data/listsData';
import ListsCard from '../components/Cards/ListsCard';
import PropTypes from 'prop-types';
//import AddListForm from '../components/Forms/AddListForm';

function MyListsView({ user, lists, setLists }) {
  const [showButton, setShowButton] = useState(false);
  const handleClick = () => {
    setShowButton((prevState) => !prevState);
  };

  return (
    <div className='myListsView'>
      <section className="header mt-2">
      { !showButton
        ? <Button className="m-2 btn-lg" color='primary' onClick={handleClick}>Add A List</Button>
        : <div>
            <Button className="m-2 btn-lg" color='info' onClick={handleClick}>Close</Button>
            {/* <AddListForm className="justify-content-center mt-3" setLists={setLists} user={user} lists={lists} formTitle={'Add New List'}/> */}
          </div>
      }
      </section>
      {lists.length === 0
        && <h3 className="text-center mt-2">No Lists Yet</h3>
      }
      <div className="card-container" id="list-cards">
        {lists?.map((listInfo) => (
          <ListsCard
          key={listInfo.Id}
          listName={listInfo.listName}
          user={user}
          setLists={setLists}
          />
        ))}
      </div>  
    </div>
  );
}

MyListsView.propTypes = {
  user: PropTypes.any,
  lists: PropTypes.array.isRequired,
  setLists: PropTypes.any
};

export default MyListsView;