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
    const { email, password, rePassword} = ctx.params;
    //console.log(ctx.params);
    if(password !== rePassword){
        throw new Error('Passwords do not match');
    }

    registerUser(email, password)
    .then(res => {
        console.log(res.user);
        saveUserInfo(res.user.email);
        ctx.redirect('#/home');
    })
    .catch(e=>console.log(e));
}

export function postLogin(ctx){
    const { email, password } = ctx.params;

    login(email, password)
    .then(res => {
        //console.log(sessionStorage);
        //console.log(res);
        saveUserInfo(res.user.email);
        //notify('Logged in!', '#successBox');
        // setTimeout(()=>{
        //     ctx.redirect('#/home');

        // }, 5000)
        ctx.redirect('#/home');
    })
    .catch(e=>{
        console.log(e);
        //notify(`${e.message}`, '#errorBox')
    });;
}

export function getLogout(ctx){    
    logout()
    .then(res => {
        sessionStorage.clear();
        ctx.redirect('#/home');
    })
    .catch(e => console.log(e));
}

    // НОТИФИКАЦИИ
// function notify(message, selector){
//     const notification = document.querySelector(selector);
//         notification.textContent = message;
//         notification.style.display = 'block';
// }

// function getEventsByUser(user){
//     getAll()
//     .then(res => {
//         //console.log(res.docs[0].data()); // разглежда един обект от масива с events
//         const events = res.docs.map(x => x = { ...x.data(), id: x.id});
//         let userEvents = events.filter(e=>e.organizer === user)
//         console.log(userEvents);
//     })
// }