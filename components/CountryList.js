import React, { useEffect, useState } from "react";
import { getCountries, deleteCountry } from "../api";

const CountryList = () => {
  const [countries, setCountries] = useState([]);

  const fetchCountries = async () => {
    const data = await getCountries();
    setCountries(data);
  };

  useEffect(() => {
    fetchCountries();
  }, []);

  const handleDelete = async (id) => {
    await deleteCountry(id);
    fetchCountries(); // refresh after delete
  };

  return (
    <div>
      <h2>Olympic Medals</h2>
      <table>
        <thead>
          <tr>
            <th>Country</th>
            <th>Gold</th>
            <th>Silver</th>
            <th>Bronze</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {countries.map((country) => (
            <tr key={country.id}>
              <td>{country.name}</td>
              <td>{country.gold}</td>
              <td>{country.silver}</td>
              <td>{country.bronze}</td>
              <td>
                <button onClick={() => handleDelete(country.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default CountryList;
