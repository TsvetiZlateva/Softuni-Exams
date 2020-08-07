// ползва се при регистрация и логване
export function saveUserInfo(userInfo){
    sessionStorage.setItem('user', userInfo);
}

//сетва се при get на view-тата
export function setHeader(ctx){
    ctx.isAuth = sessionStorage.getItem('user') !== null;
    ctx.user = sessionStorage.getItem('user');
}

