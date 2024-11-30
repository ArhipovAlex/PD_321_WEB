import React from "react";

class Footer extends React.Component
{
    render()
    {
    return(
        <footer style={{background:"#323232", color:"aliceblue", padding:"25px"}}>
            <p>Copyright &#169; - {this.props.year}</p>
        </footer>
    );}
}

export default Footer;