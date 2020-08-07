import commonPartial from './partials.js'
import { setHeader } from './auth.js'
import { create, get, update, close } from '../models/events.js';

export function getCreate(ctx){
    setHeader(ctx);
    ctx.loadPartials(commonPartial).partial('./view/events/create.hbs');
}

export function postCreate(ctx){
    console.log(ctx);
    console.log(ctx.params);
    console.log(sessionStorage);

    const { title, category, content } = ctx.params;
    const creator = sessionStorage.getItem('user');
    console.log(creator);
    //const interestedIn = 0;
    //console.log({ name, dateTime, description, imageURL });
    create({ title, category, content, creator })
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
        console.log(res);
        const event = {...res.data(), id : res.id};
        ctx.isCreator = event.creator === sessionStorage.getItem('user');
        ctx.event = event;
        //console.log(event);
        ctx.loadPartials(commonPartial).partial('./view/events/details.hbs');
    })
    .catch(e=>console.log(e));
}

export function getEdit(ctx){
    setHeader(ctx);
    const id = ctx.params.id;
    console.log(ctx.params);
    get(id)
    .then( res=>{
        const event = {...res.data(), id : res.id};
        ctx.event = event;
        ctx.loadPartials(commonPartial).partial('./view/events/edit.hbs');
    })
    .catch(e=>console.log(e));
}

export function postEdit(ctx){
    const { title, category, content } = ctx.params;
    const id = ctx.params.id;
    console.log(ctx.params);
    update(id, { title, category, content })
    .then(res=>{
        //ctx.redirect(`#/details/${id}`);
        ctx.redirect(`#/home`);
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