function Fib(props)
{
    let a=props.a, prev=0,next=1,result="";
    while(next<a)
    {
        next = prev + next;
        result=result+prev+" ";
        prev = next - prev;
    }
    result=result+prev+" ";
    return(
        <h3>{result} </h3>
    )
}

export default Fib;