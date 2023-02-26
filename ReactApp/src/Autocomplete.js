import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './custom.css';
import API_CONFIG from './api-config';

const Autocomplete = () => {
  const [query, setQuery] = useState('');
  const [results, setResults] = useState([]);
  const [tableData, setTableData] = useState([]);  
  const lookupUrl = `${API_CONFIG.BASE_URL}${API_CONFIG.LOOKUP_ENDPOINT}`;

  useEffect(() => {
    async function fetchData()
    {
      const autocompleteUrl = `${API_CONFIG.BASE_URL}${API_CONFIG.AUTOCOMPLETE_ENDPOINT}`;
            if (query.length > 0) {
            await axios.get(`${autocompleteUrl}?postcode=${query}`)
                .then(response => {
                    if(response.data[0] !== query && response.data.length > 0){
                    setResults(response.data);
                    }
                    else {
                      setResults([]);
                    }
                })
                .catch(error => {
                console.log(error);
                });
            }
    }
    fetchData();
  }, [query]);

  const handleChange = event => {
    setQuery(event.target.value);
  };

  const onSearch=(searchitem)=>{
    setResults([]);
    setQuery(searchitem);    
  }

  const handleSearch = async () => {
    await axios.get(`${lookupUrl}?postcode=${query}`)
        .then(response => {
            console.log(response.data);
            setTableData(response.data);
        })
        .catch(error => {
          console.log(error);
        });    
  };

  return (
    <div className="container">
      <div className='search-container'>
        <br /><br />
          <div className='row col-md-12'>
              <input type="text" id="search-box" className='form-control input col-md-5'
              style={{marginLeft:10}} 
              value={query} onChange={handleChange}              
              />
              <ul id="suggestions" className='col-md-5' style={{marginLeft:12}} >
                  {
                  results.length>0 && results.map(result => (
                        <li onClick={()=>onSearch(result)} data-testid="row"                       
                            key={result}>
                            {result}
                        </li>
                    ))
                  }
                </ul>
              <button className='btn btn-primary col-md-3' style={{marginLeft: 5}} 
              onClick={handleSearch}>Search</button>
              
          </div>
          <div className="col-md-10">
            
          </div>
      </div>
      <br />
      <h4>PostCode Table</h4>        
      <table className="table table-bordered " id="search-results">
                <thead>
                    <tr class="table-warning">
                    <th scope="col">Country</th>
                    <th scope="col">Region</th>
                    <th scope="col">Admin District</th>
                    <th scope="col">Parliamentary Constituency</th>
                    <th scope="col">Area</th>
                    </tr>
                </thead>
                <tbody>
            {
               tableData.length>0 && tableData.map((result) => (
                            <tr key={result.postcode}>
                                <td>{result.country}</td>
                                <td>{result.region}</td>
                                <td>{result.adminDistrict}</td>
                                <td>{result.parliamentaryConstituency}</td>
                                <td>{result.area}</td>
                            </tr>
                ))
            }
        </tbody>
        </table>      
    </div>
  );
};

export default Autocomplete;
