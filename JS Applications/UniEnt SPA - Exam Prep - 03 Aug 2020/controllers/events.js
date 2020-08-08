import commonPartial from './partials.js'
import { setHeader } from './auth.js'
import { create, get, update, close } from '../models/events.js';

export function getCreate(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/events/create.hbs');
}

export function postCreate(ctx){
    const { name, dateTime, description, imageURL } = ctx.params;
    const organizer = sessionStorage.getItem('user');
    const interestedIn = 0;
    //console.log({ name, dateTime, description, imageURL });
    create({ name, dateTime, description, imageURL, organizer, interestedIn })
    .then(res => {
        //console.log(res);
        ctx.redirect('#/home');
    })
    .catch(e=>console.log(e));
}

export function getDetails(ctx){
    setHeader(ctx);
    const id = ctx.params.id;
    console.log(ctx.params);
    get(id)
    .then( res=>{
        const event = {...res.data(), id : res.id};
        ctx.isOrganizer = event.organizer === sessionStorage.getItem('user');
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
    const { name, dateTime, description, imageURL } = ctx.params;
    const id = ctx.params.id;
    update(id, { name, dateTime, description, imageURL })
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
        const interestedIn = event.interestedIn + 1;
        
        update(id, {interestedIn})
        .then(res=>{
            ctx.redirect(`#/details/${id}`);
    })
    .catch(e=>console.log(e));
    })
    .catch(e=>console.log(e));
}