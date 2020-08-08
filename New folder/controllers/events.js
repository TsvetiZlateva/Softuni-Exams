import commonPartial from './partials.js'
import { setHeader } from './auth.js'
import { create, get, update, close } from '../models/events.js';

export function getCreate(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/events/create.hbs');
}

export function postCreate(ctx){
    const { title, description, imageUrl } = ctx.params;
    const creator = sessionStorage.getItem('user');
    const likes = 0;
    const liked = [];
    create({ title, description, imageUrl , creator, likes, ...liked })
    .then(res => {
        ctx.redirect('#/home');
    })
    .catch(e=>console.log(e));
}

export function getDetails(ctx){
    setHeader(ctx);
    const id = ctx.params.id;

    get(id)
    .then( res=>{
        const event = {...res.data(), id : res.id};
        ctx.isCreator = event.creator === sessionStorage.getItem('user');
        ctx.event = event;
        ctx.loadPartials(commonPartial).partial('./view/events/details.hbs');
    })
    .catch(e=>console.log(e));
}

export function getEdit(ctx){
    setHeader(ctx);
    const id = ctx.params.id;
    get(id)
    .then( res=>{
        const event = {...res.data(), id : res.id};
        ctx.event = event;
        ctx.loadPartials(commonPartial).partial('./view/events/edit.hbs');
    })
    .catch(e=>console.log(e));
}

export function postEdit(ctx){
    const { title, description, imageUrl  } = ctx.params;
    const id = ctx.params.id;
    update(id, { title, description, imageUrl })
    .then(res=>{
        ctx.redirect(`#/details/${id}`);
    })
    .catch(e=>console.log(e));
}

export function getClose(ctx){
    const id = ctx.params.id;
    close(id)
    .then(res=>{
        ctx.redirect('#/home');
    })
    .catch(e=>console.log(e));
}

export function getJoin(ctx){
    const id = ctx.params.id;
    get(id)
    .then(res=>{
        const event = res.data();
        const likes = event.likes + 1;
        event.liked.push(sessionStorage.user);
        const liked = event.liked;
       
        update(id, {likes, liked})
        .then(res=>{
            ctx.redirect(`#/details/${id}`);
    })
    .catch(e=>console.log(e));
    })
    .catch(e=>console.log(e));
}