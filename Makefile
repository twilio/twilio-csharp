.PHONY: clean test install release docs

clean:
	dotnet clean

install:
	@dotnet --version || (echo "Dotnet is not installed, please install Dotnet CLI"; exit 1);
	dotnet restore

test:
	dotnet build -c Release
	dotnet test -c Release

release:
	dotnet pack -c Release

docs:
	doxygen Doxyfile

API_DEFINITIONS_SHA=$(shell git log --oneline | grep Regenerated | head -n1 | cut -d ' ' -f 5)
docker-build:
	docker build -t twilio/twilio-csharp .
	docker tag twilio/twilio-csharp twilio/twilio-csharp:${TRAVIS_TAG}
	docker tag twilio/twilio-csharp twilio/twilio-csharp:apidefs-${API_DEFINITIONS_SHA}
	docker tag twilio/twilio-csharp twilio/twilio-csharp:latest

docker-push:
	echo "${DOCKER_PASSWORD}" | docker login -u "${DOCKER_USERNAME}" --password-stdin
	docker push twilio/twilio-csharp:${TRAVIS_TAG}
	docker push twilio/twilio-csharp:apidefs-${API_DEFINITIONS_SHA}
	docker push twilio/twilio-csharp:latest
