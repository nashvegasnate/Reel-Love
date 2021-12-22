import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {
  Form, Button, Input, Label
} from 'reactstrap';
import getMovieByTitle from '../helpers/data/moviesData';
import MovieCard from '../components/MovieCard';

function TitleSearchForm({ user, setMovie }) {
  const [searchTitle, setSearchTitle] = useState('');
  const [searchResult, setSearchResult] = useState([]);

  const handleInputChange = (e) => {
    setSearchTitle((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value,
    }));
  }

  const handleSearch = (e) => {
    e.preventDefault();
    getMovieByTitle(searchTitle.searchInput).then((response) => {
      setSearchResult(response);
    });

    // clears input fields
    setSearchTitle({
      [e.target.name]: ''
    });
  };

  return (
    <div className="search-form">
      <Form id="TitleSearchForm" autoComplete="off" onSubmit={handleSearch}>
        <Label for="Search Titles">Search Titles</Label>
        <Input
          name="SearchInput"
          id="SearchInput"
          type="text"
          placeholder="Search By Movie Title"
          onChange={handleInputChange}
        />
        <Button type="submit" color="info">Search</Button>
      </Form>
      <div className="item-container">
        {searchResult.length > 0
        && (
          <MovieCard
            key={searchResult[0].Title}
            ImdbID={searchResult[0].ImdbID}
            Title={searchResult[0].Title}
            Genre={searchResult[0].Genre}
            Runtime={searchResult[0].Runtime}
            Year={searchResult[0].Year}
            Poster={searchResult[0].Poster}
            Plot={searchResult[0].Plot}
            user={user}
            setMovie={setMovie}
          />
        )}
      </div>
    </div>
  );
}

TitleSearchForm.propTypes = {
  user: PropTypes.any.isRequired,
  movie: PropTypes.object,
  setMovie: PropTypes.any
};

export default TitleSearchForm;