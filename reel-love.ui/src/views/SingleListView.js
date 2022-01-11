import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useParams } from 'react-router-dom';
import ListCard from '../components/Cards/ListsCard';
import { getListById } from '../helpers/data/listsData';
//import { getMovieByImdbID } from '../helpers/data/MoviesData';

function SingleListView({ user }) {
  const [list, setList] = useState([]);
  const { listParam } = useParams();

  useEffect(() => {
    getListById(listParam).then(setList);
    console.warn(listParam);
  }, [listParam]);

  return (
    <div>
      <h3>SINGLE LIST VIEW</h3>
      {
        list.length > 0
        && <ListCard
        listName={list.listName}
        user={user}
        />
      }
    </div>
  );
}

SingleListView.propTypes = {
  user: PropTypes.any.isRequired,
  list: PropTypes.array
};

export default SingleListView;