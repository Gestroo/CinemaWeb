import axios from 'axios';
import {Answer, LoginModel, RegistrationModel} from "../../models/RequestModel";
import {removeCookie, setCookie} from "typescript-cookie";
import {RegisterSuccess, RegisterFail, LoginSuccess, LoginFail, Logout} from "../actions/authActions"
import {Client} from "../../models/ClientModel";
import {clientActions} from "../slices/clientslice";

const API_URL = "http://localhost:8080/auth/";


class AuthService {
	register(reg: RegistrationModel) {
		console.log(reg)
		return axios.post(API_URL + "register", reg)
			.then((res) => {
					setCookie("access_token", res.data.accessToken, {expires: 365, path: ''});
					const client: Client = res.data.user;
					localStorage.setItem('user', JSON.stringify(client))
					return clientActions.registerSuccess({isAuth: true, client: client});
			}).catch((err) => {
				return RegisterFail(err);
			})
	}

	login(login: LoginModel) {
		return axios.post(API_URL + "login", login).then(
			(res) => {
					setCookie("access_token", res.data.accessToken, {expires: 365, path: ''});
					const client: Client = res.data.user;
					localStorage.setItem('user', JSON.stringify(client));
					return clientActions.loginSuccess({isAuth: true, client: client});
			}).catch((err) => {
			return LoginFail(err);
		})
	}
	logout(){
		removeCookie("access_token", {path: ''});
		localStorage.removeItem('user');
		return clientActions.logout();
	}
}
export default new AuthService();