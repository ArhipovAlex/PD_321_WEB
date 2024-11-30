function Fact(props)
{
    let a=props.a;
    let result=1;
    for (let i =a;i>1;i--)
    {
        result*=i;
    }
    return(
        <h3>{a}!={result}</h3>
    )
}

export default Fact;