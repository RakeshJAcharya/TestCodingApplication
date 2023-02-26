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
                    if(response.data[0] !== query){
                    setResults(response.data);
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
        <br /><br />
        <h4>Autocomplete Search</h4> 
        <div className='row col-md-6'>
            <input type="text" className='form-control input col-md-5'
            style={{marginLeft:10}}
            value={query} onChange={handleChange}
            onBlur={()=>{              
                /* setTimeout(()=>{
                    setResults([]);
                },100); */
            }} 
            />
            <button className='btn btn-primary col-md-3' style={{marginLeft: 5}} 
            onClick={handleSearch}>Search</button>
         </div>
      <div className="dropdown col-md-10" style={{marginLeft: -8}}>
      {
       results.length>0 && results.map(result => (
            <div onClick={()=>onSearch(result)}
                className=' suggestion dropdown-row col-md-3' 
                key={result}>
                {result}
            </div>
        ))
      }
      </div>
      <br /><br />
      <h4>Table with Autocomplete Search</h4>  
      <table className="table table-bordered">
                <thead>
                    <tr>
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
