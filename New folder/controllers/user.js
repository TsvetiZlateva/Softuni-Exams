import commonPartial from './partials.js'
import { registerUser, login, logout } from '../models/user.js';
import { saveUserInfo, setHeader } from './auth.js';

export function getLogin(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/user/login.hbs')
}

export function getProfile(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/user/profile.hbs')
}

export function getRegister(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/user/register.hbs')
}

export function postRegister(ctx){
    const { email, password, repeatPassword} = ctx.params;
    console.log(ctx.params);
    if(password!== repeatPassword){
        throw new Error('Passwords do not match');
    }

    registerUser(email, password)
    .then(res => {
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
        console.log(res);
        saveUserInfo(res.user.email);
        ctx.redirect('#/home');
    })
    .catch(e => console.log(e));
}

export function getLogout(ctx){    
    logout()
    .then(res => {
        sessionStorage.clear();
        ctx.redirect('#/login');
    })
    .catch(e => console.log(e));
}

