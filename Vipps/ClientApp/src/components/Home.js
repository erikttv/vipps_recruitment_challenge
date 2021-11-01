import React, {useState} from 'react';
import {TextField, Grid, Button} from "@material-ui/core";

const Home = ()=>{
    
    const [searchWord, setSearchWord] = useState("");
    const [numSearchWord, setNumSearchWord] = useState(0);
    const [longText, setLongText] = useState("Du har ikke søkt på noe enda.");
    
    const handleSearchWord = (event) =>{
        setSearchWord(event.target.value);
    };
    
    const handleSubmit = (event) =>{
        if(searchWord != ""){
            setLongText("Henter fra wikipedia og analyserer...");
            setNumSearchWord(0);
            fetch("api/Wikipedia?searchTopic=" + searchWord)
                .then(res => res.json())
                .then((result)=>{
                    setLongText(result.parse.text.actualText);
                    setNumSearchWord(result.parse.numTopic);
                });
        } else {
            setLongText("OBS! Du må skrive inn minst en bokstav!");
            setNumSearchWord(0);
        } 
    }
    
    return (
        <>
            <h1>Oppgave for Vipps</h1>
            <Grid container spacing={2}>
                <Grid item xs={4}>
                        <p>
                            Skriv inn et ord under.
                            Du kan for eksempel skrive "plane".
                            Når du klikker på "Hent antall ord i artikkelen" vil den bruke API-et til wikipedia for å hente riktig artikkel.
                            Deretter teller den opp antall ganger ordet er brukt i den artikkelen.
                            Antall ganger ordet blir brukt blir printet på skjermen.
                        </p>
                        <TextField id="standard-basic" label="søkeord" variant="standard" value={searchWord} onChange={handleSearchWord}/>
                        <br/>
                        <br/>
                        <Button variant="contained" onClick={handleSubmit}>Hent antall ord i artikkelen</Button>
                        <h2>Antall ganger i teksten: {numSearchWord}</h2>
                </Grid>
                <Grid item xs={8}>
                    <p>{longText}</p>
                </Grid>
            </Grid>
        </>
    )
}

export default Home;