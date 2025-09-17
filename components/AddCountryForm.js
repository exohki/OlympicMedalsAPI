import React, { useState } from "react";
import { addCountry } from "../api";

const AddCountryForm = ({ onAdd }) => {
  const [name, setName] = useState("");
  const [gold, setGold] = useState(0);
  const [silver, setSilver] = useState(0);
  const [bronze, setBronze] = useState(0);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!name) return;

    await addCountry({ name, gold, silver, bronze });
    setName("");
    setGold(0);
    setSilver(0);
    setBronze(0);
    onAdd(); // refresh the list
  };

  return (
    <form onSubmit={handleSubmit}>
      <h3>Add Country</h3>
      <input
        type="text"
        placeholder="Country Name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <input
        type="number"
        placeholder="Gold"
        value={gold}
        onChange={(e) => setGold(parseInt(e.target.value))}
      />
      <input
        type="number"
        placeholder="Silver"
        value={silver}
        onChange={(e) => setSilver(parseInt(e.target.value))}
      />
      <input
        type="number"
        placeholder="Bronze"
        value={bronze}
        onChange={(e) => setBronze(parseInt(e.target.value))}
      />
      <button type="submit">Add</button>
    </form>
  );
};

export default AddCountryForm;
