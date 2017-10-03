# ios11-webclip-auth-cookie-issue

There appears to be an issue with iOS 11, home screen web apps (web clips), and cookies (as of iOS 11.0.1). When a cookie is set from the server, iOS 11 seems to intermittently delete the cookie. Other times, when the server expires a cookie, iOS 11 appears to intermittently fail to delete the cookie. These two behaviors occur after closing and re-opening the home screen web app and don't seem to be reproducible in Safari. These behaviors also don't appear to be present in iOS 10 or iOS 9.

#### Steps to reproduce:

1. Clone this repo and point an ASP.NET 4.5 application directory in IIS to the `LoginTest` directory

2. Launch the site in Mobile Safari in iOS 11 and click the "Login" button (so you can get to the root URL instead of the login page)

3. Add the app to home screen

4. Launch the app and try logging in

5. Close the app and re-open it. At this point you may find that you are no longer logged in, or you may find that your are still logged in. The issue is intermittent.

6. If you are still logged in, try logging out.

7. Close the app and re-open it. You may find that you have been logged out, or you may still be logged in.

If you don't notice any issues right away, repeat steps 4 - 7 until you either are kept logged in after logging out, or you are logged out when you should be logged in.

