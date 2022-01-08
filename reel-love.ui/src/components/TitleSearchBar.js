import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {
  Form, Button, Input, Label
} from 'reactstrap';
import { getMovieTitle } from '../helpers/data/MoviesData';
import MovieCard from '../components/Cards/MovieCard';

function TitleSearchBar({ user }) {
  //const [searchResults, setSearchResults] = useState([]);
  // OR should it be an object?
  const [searchResults, setSearchResults] = useState({});
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
    getMovieTitle(searchTitle).then((response) => {
      setSearchResults({...response});
      console.warn(searchResults);
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
        {searchResults.imdbID
        ?
          <MovieCard
            key={searchResults.ImdbID}
            imdbID={searchResults.ImdbID}
            title={searchResults.title}
            genre={searchResults.genre}
            runtime={searchResults.runtime}
            year={searchResults.year}
            poster={searchResults.poster}
            plot={searchResults.plot}
            user={user}
            //setMovies={setMovies}
            searchResults={searchResults}
          /> 
        : <></>}  
      </div>
    </div>
  );
}

TitleSearchBar.propTypes = {
  user: PropTypes.any,
  movie: PropTypes.array,
  //setMovies: PropTypes.any
};

export default TitleSearchBar;