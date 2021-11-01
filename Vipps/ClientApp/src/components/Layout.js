import React from 'react';
import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles(()=>({
    layout: {
        marginTop: "5%",
        marginLeft: "50px",
        marginRight: "50px",
    }
}));

function Layout ({children}){
    const classes = useStyles();
    return (
       <>
           <div className={classes.layout}>
               {children}
           </div>
       </>
    )
}

export default Layout;