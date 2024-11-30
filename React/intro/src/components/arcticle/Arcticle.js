import male from './icons/male.png'
import female from './icons/female.png'
import './Arcticle.css';

function Arcticle(props) {
    console.log(props.db);

    return (
        <div className='app'>
            {
        Object.keys(props.db["people"]).map(item => {
            let icon = props.db["people"][item].pol === "male" ? male : female;
            return (
            <div className="card" key={item}>
                <img src={props.db["people"][item].photo} alt="" />
                <div className="name">
                    {props.db["people"][item].name + " " + props.db["people"][item].surname}
                </div>
                <div className="pol">
                    <img src={icon} alt="" />
                </div>
                <div className="age">
                    {props.db["people"][item].age}
                </div>
            </div>
        )
            }
        )
    }
        </div>
    );        
}

export default Arcticle;