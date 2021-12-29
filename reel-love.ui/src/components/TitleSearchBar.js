import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {
  Form, Button, Input, Label
} from 'reactstrap';
import getMovieTitle from '../helpers/data/moviesData';
import MovieCard from '../components/MovieCard';

function TitleSearchBar({ user }) {
  const [searchResult, setSearchResult] = useState([]);
  // OR should it be an object?
  //const [searchResult, setSearchResult] = useState({});
  const [searchTitle, setSearchTitle] = useState('');

  // const handleInputChange = (e) => {
  //   setSearchTitle((prevState) => ({
  //     ...prevState,
  //     [e.target.name]: e.target.value,
  //   }));
  // };

  const handleInputChange = (e) => {
    setSearchTitle(e.target.value);
  };

  const handleSearch = (e) => {
    e.preventDefault();
    console.warn(searchTitle);
    getMovieTitle(searchTitle).then((response) => {
      setSearchResult(response);
      setSearchTitle(''); //clears input fields
    });
  };

  return (
    <div className="search-form">
      <Form id="TitleSearchBar" autoComplete="off" onSubmit={handleSearch}>
        <Label for="Search Titles">Search Titles</Label>
        <Input
          name="SearchInput"
          id="SearchInput"
          type="text"
          value={searchTitle}
          placeholder="Search Movie Title"
          required
          onChange={handleInputChange}
        />
        <Button type="submit" color="info">Search</Button>
      </Form>
      <div className="movie-container">
        {searchResult.length > 0
        && (
          <MovieCard
            key={searchResult.title}
            imdbID={searchResult.imdbID}
            yitle={searchResult.title}
            genre={searchResult.genre}
            runtime={searchResult.runtime}
            year={searchResult.year}
            poster={searchResult.poster}
            plot={searchResult.plot}
            user={user}
            //setMovie={setMovie}
          />
        )}
      </div>
    </div>
  );
}

TitleSearchBar.propTypes = {
  user: PropTypes.any.isRequired,
  // movie: PropTypes.object,
  // setMovie: PropTypes.any
};

export default TitleSearchBar;