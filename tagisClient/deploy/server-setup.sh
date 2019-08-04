#!/bin/bash

# Download and install updates
sudo yum update -y;

# Download and install Apache, turn on at boot, and start service
sudo yum install httpd -y;
sudo chkconfig httpd on; 
sudo service httpd start;

# Install NPM dependencies
# Install Ruby and GCC
sudo yum groupinstall 'Development Tools' -y && sudo yum install curl git m4 ruby texinfo bzip2-devel curl-devel expat-devel ncurses-devel zlib-devel -y;

#Install Node.js
curl -sL https://rpm.nodesource.com/setup_8.x | sudo -E bash -;
sudo yum install nodejs -y;

# Install NPM version 5.3.0
sudo npm install npm@5.3.0 -g;

# Install typescript, typings, and Angular CLI globally
sudo npm install -g typescript -y;
sudo npm install -g typings -y;
# sudo npm install -g @angular/cli -y;

# Clone from the Git repository
# $branch = 'master';

# if[ "$0" != ""] then
#   $branch = $0;
# fi

# Get SSH key
aws s3 cp s3://the-advent-group/id_rsa /root/.ssh/id_rsa;
chmod 600 /root/.ssh/id_rsa;
ssh-agent bash -c 'ssh-add /home/root/.ssh/id_rsa;';
eval "$(ssh-agent -s)";
ssh-add /home/root/.ssh/id_rsa -y;

sudo git clone git@github.com:loganfarr/tagis.git /var/www/html/;

# Install NPM modules
cd /var/www/html;
sudo npm install;
