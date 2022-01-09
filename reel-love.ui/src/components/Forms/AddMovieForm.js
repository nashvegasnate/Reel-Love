import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {
  Button,
  FormGroup,
  Form,
  Input,
  Label
} from 'reactstrap';
import { addMovie, editMovie } from '../../helpers/data/MoviesData';

const AddMovieForm = ({
  title,
  imdbID,
  genre,
  runtime,
  year,
  plot,
  poster,
  user

}) => {
  const [searchResults, setSearchResults ] = useState({
    title: title || '',
    imdbID: imdbID || '',
    genre: genre || '',
    runtime: runtime || '',
    year: year || '',
    plot: plot || '',
    poster: poster || '',
    user: user.uid || null
  });

  const history = useHistory();

  const handleInputChange = (e) => {
    setSearchResults((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value
    }));
  }
};

const handleSubmit = (e) => {
  e.preventDefault();
  if (searchResults.imdbID)

}