import axios from "axios";

// Update this to your Azure API URL
const API_URL = "https://olympicmedals.azurewebsites.net/api/country";

export const getCountries = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export const getCountry = async (id) => {
  const response = await axios.get(`${API_URL}/${id}`);
  return response.data;
};

export const addCountry = async (country) => {
  const response = await axios.post(API_URL, country);
  return response.data;
};

export const deleteCountry = async (id) => {
  await axios.delete(`${API_URL}/${id}`);
};
