FROM tiangolo/node-frontend:10 as build-stage
COPY package*.json /app/
RUN npm install
COPY ./ /app/
ARG configuration=production
RUN npm run build -- --output-path=./dist/out --configuration $configuration

# Stage 1, based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:stable-alpine
COPY --from=build-stage /app/dist/out/ /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
#COPY aks-ingress-tls.crt /usr/share/aks-ingress-tls.crt
#COPY aks-ingress-tls.key /usr/share/aks-ingress-tls.key
# Copy the default nginx.conf provided by tiangolo/node-frontend
COPY --from=build-stage /nginx.conf /etc/nginx/conf.d/default.conf
