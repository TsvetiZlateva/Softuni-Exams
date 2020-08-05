import commonPartial from './partials.js'
import { registerUser, login, logout } from '../models/user.js';
import { saveUserInfo, setHeader } from './auth.js';
import { get, getAll } from '../models/events.js';

export function getLogin(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/user/login.hbs')
}

export function getProfile(ctx){
    setHeader(ctx);
    // const user = ctx.user; // user's email
    // const events = getEventsByUser(user);
    
    //console.log(ctx.user);
    ctx.loadPartials(commonPartial).partial('./view/user/profile.hbs')
}

export function getRegister(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/user/register.hbs')
}

export function postRegister(ctx){
    //console.log(ctx);
    const { username, password, rePassword} = ctx.params;
    if(password!== rePassword){
        throw new Error('Passwords do not match');
    }

    registerUser(username, password)
    .then(res => {
        console.log(res.user);
        saveUserInfo(res.user.email);
        ctx.redirect('#/home');
    })
    .catch(e=>console.log(e));
}

export function postLogin(ctx){
    const { username, password } = ctx.params;

    login(username, password)
    .then(res => {
        //console.log(sessionStorage);
        //console.log(res);
        saveUserInfo(res.user.email);
        notify('Logged in!', '#successBox');
        setTimeout(()=>{
            ctx.redirect('#/home');

        }, 5000)
    })
    .catch(e=>{
        notify(`${e.message}`, '#errorBox')
    });;
}

export function getLogout(ctx){    
    logout()
    .then(res => {
        sessionStorage.clear();
        ctx.redirect('#/login');
    })
    .catch(e => console.log(e));
}

function notify(message, selector){
    const notification = document.querySelector(selector);
        notification.textContent = message;
        notification.style.display = 'block';
}

// function getEventsByUser(user){
//     getAll()
//     .then(res => {
//         //console.log(res.docs[0].data()); // разглежда един обект от масива с events
//         const events = res.docs.map(x => x = { ...x.data(), id: x.id});
//         let userEvents = events.filter(e=>e.organizer === user)
//         console.log(userEvents);
//     })
// }