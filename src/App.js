import React, { useState } from "react";
import CountryList from "./components/CountryList";
import AddCountryForm from "./components/AddCountryForm";

function App() {
  const [refresh, setRefresh] = useState(false);

  return (
    <div className="App">
      <h1>Olympic Medals Tracker</h1>
      <AddCountryForm onAdd={() => setRefresh(!refresh)} />
      <CountryList key={refresh} />
    </div>
  );
}

export default App;
