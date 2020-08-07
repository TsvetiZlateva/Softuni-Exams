import commonPartial from './partials.js'
import { setHeader } from './auth.js'
import { getAll } from '../models/events.js';

export function getHome(ctx){
    setHeader(ctx);
    getAll()
    .then(res => {
        //console.log(res.docs[0].data()); // разглежда един обект от масива с events
        const articles = res.docs.map(x => x = { ...x.data(), id: x.id});
        ctx.events = articles;
        //console.log(res.docs.length);
        //ctx.haveArticles = ctx.events.length !== 0;
        const authorsArticles = ctx.events.filter(a=>a.creator === sessionStorage.user);
        ctx.isAuthor = authorsArticles.length > 0;
        ctx.authorsArticles = authorsArticles;
        console.log(ctx);
        console.log(ctx.events);
        //setCategory(articles);
        ctx.loadPartials(commonPartial).partial('./view/home.hbs');
    })
}

function setCategory(articles){
    const JavaScriptCategory = document.querySelector(".js");
    const cSharpCategory = document.querySelector(".CSharp");
    const JavaCategory = document.querySelector(".Java");
    const PytonCategory = document.querySelector(".Pyton");
}