import React, { useState, useEffect } from 'react';
import { Button } from 'reactstrap';
import { getLists } from '../helpers/data/ListsData';
import { useHistory } from 'react-router-dom';
//import ListsCard from '../components/Cards/ListsCard';
import PropTypes from 'prop-types';
import AddListForm from '../components/Forms/AddListForm';

function MyListsView({ user }) {
  const [lists, setLists] = useState([]);
  const [showButton, setShowButton] = useState(false);
  const handleClick = () => {
    setShowButton((prevState) => !prevState);
  };
  const history = useHistory();

  useEffect(() => {
    getLists().then(setLists);
  }, []);

  const handlePush = (Id) => {
    history.push(`/listsSingleView/${Id}`);
    console.warn(Id);
  };

  return (
    <div className='myListsView'><h3>ALL LISTS</h3>
      <section className="header mt-2">
      { !showButton
        ? <Button className="m-2 btn-lg" color='primary' onClick={handleClick}>Add A List</Button>
        : <div>
            <Button className="m-2 btn-lg" color='info' onClick={handleClick}>Close</Button>
            <AddListForm className="justify-content-center mt-3" setLists={setLists} user={user} lists={lists} formTitle={'Add New List'}/>
          </div>
      }
      </section>
      {lists?.length === 0
        && <h3 className="text-center mt-2">No Lists Yet</h3>
      }
      <div className="card-container" id="list-cards">
        {lists?.map((list, Id) => (
          <h3 key={Id}>
            <Button className='mt-3' onClick={() => handlePush(list.Id)}>{list.listName}</Button>
          </h3>
          // <ListsCard
          // key={listInfo.Id}
          // listName={listInfo.listName}
          // user={user}
          // setLists={setLists}
          // />
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